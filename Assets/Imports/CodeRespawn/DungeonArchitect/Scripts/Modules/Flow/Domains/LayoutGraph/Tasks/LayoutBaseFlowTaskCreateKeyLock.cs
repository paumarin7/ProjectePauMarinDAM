using System;
using System.Collections.Generic;
using System.Linq;
using DungeonArchitect.Flow.Exec;
using DungeonArchitect.Flow.Items;
using DungeonArchitect.Utils;

namespace DungeonArchitect.Flow.Domains.Layout.Tasks
{
    public class LayoutBaseFlowTaskCreateKeyLock : FlowExecTask
    {
        public string keyBranch = "main";
        public string lockBranch = "main";
        public string keyMarkerName = "Key";
        public string lockMarkerName = "Lock";


        protected virtual bool Validate(FlowTaskExecContext context, FlowTaskExecInput input, ref string errorMessage, ref FlowTaskExecutionResult executionResult)
        {
            return true;
        }

        public override FlowTaskExecOutput Execute(FlowTaskExecContext context, FlowTaskExecInput input)
        {
            var output = new FlowTaskExecOutput();
            if (input.IncomingTaskOutputs.Length == 0)
            {
                output.ErrorMessage = "Missing Input";
                output.ExecutionResult = FlowTaskExecutionResult.FailHalt;
                return output;
            }

            if (input.IncomingTaskOutputs.Length > 1)
            {
                output.ErrorMessage = "Only one input allowed";
                output.ExecutionResult = FlowTaskExecutionResult.FailHalt;
                return output;
            }
            
            output.State = input.CloneInputState();
            if (!Validate(context, input, ref output.ErrorMessage, ref output.ExecutionResult))
            {
                return output;
            }

            var graph = output.State.GetState<FlowLayoutGraph>();

            FlowLayoutGraphNode keyNode;
            FlowLayoutGraphLink lockLink;
            
            var graphQuery = new FlowLayoutGraphQuery(graph);
            if (FindKeyLockSetup(graphQuery, context.Random, out keyNode, out lockLink, out output.ErrorMessage))
            {
                var keyItem = new FlowItem();
                keyItem.type = FlowGraphItemType.Key;
                keyItem.markerName = keyMarkerName;
                keyNode.AddItem(keyItem);
                
                ProcessKeyItem(keyItem, keyNode, lockLink);

                var lockItem = new FlowItem();
                lockItem.type = FlowGraphItemType.Lock;
                lockItem.markerName = lockMarkerName;
                lockLink.state.AddItem(lockItem);
                
                keyItem.referencedItemIds.Add(lockItem.itemId);
                lockItem.referencedItemIds.Add(keyItem.itemId);

                output.ExecutionResult = FlowTaskExecutionResult.Success;
                return output;
            }

            output.ExecutionResult = FlowTaskExecutionResult.FailRetry;
            return output;
        }

        protected virtual void ProcessKeyItem(FlowItem keyItem, FlowLayoutGraphNode keyNode, FlowLayoutGraphLink lockLink)
        {
        }

        DungeonUID[] GetLockedNodesInPath(FlowLayoutGraphQuery graphQuery, FlowLayoutGraphLink lockLink)
        {
            var sourceNode = graphQuery.GetNode(lockLink.source);
            var destNode = graphQuery.GetNode(lockLink.destination);
            
            var disallowedNodes = new List<DungeonUID>();
            disallowedNodes.Add(destNode.nodeId);
            
            // If the link belongs to the main path, we want to disallow all the nodes in the main path after this link
            bool mainPathLink = (sourceNode != null && destNode != null && sourceNode.mainPath && destNode.mainPath);
            if (mainPathLink)
            {
                var graph = graphQuery.Graph;
                // Grab all the main path nodes after this link
                var mainPathNodeId = destNode.nodeId;
                var visited = new HashSet<DungeonUID>() {mainPathNodeId};

                while (true)
                {
                    FlowLayoutGraphLink nextLink = null;
                    foreach (var link in graph.Links)
                    {
                        if (link.state.type == FlowLayoutGraphLinkType.Unconnected) continue;
                        if (link.source == mainPathNodeId)
                        {
                            // make sure the destination node is also a main path node
                            var dest = graphQuery.GetNode(link.destination);
                            if (dest.mainPath)
                            {
                                nextLink = link;
                                break;
                            }
                        }
                    }

                    if (nextLink == null)
                    {
                        break;
                    }

                    mainPathNodeId = nextLink.destination;
                    if (visited.Contains(mainPathNodeId))
                    {
                        break;
                    }

                    visited.Add(mainPathNodeId);
                    disallowedNodes.Add(mainPathNodeId);
                }
            }

            return disallowedNodes.ToArray();
        }
        
        private bool FindKeyLockSetup(FlowLayoutGraphQuery graphQuery, System.Random random, out FlowLayoutGraphNode outKeyNode,
                out FlowLayoutGraphLink outLockLink, out string errorMessage)
        {
            var graph = graphQuery.Graph;
            var entranceNode = FlowLayoutGraphUtils.FindNodeWithItemType(graph, FlowGraphItemType.Entrance);
            if (entranceNode == null)
            {
                errorMessage = "Missing Entrance Node";
                outKeyNode = null;
                outLockLink = null;
                return false;
            }

            var keyNodes = FlowLayoutGraphUtils.FindNodesOnPath(graph, keyBranch);
            var lockNodes = FlowLayoutGraphUtils.FindNodesOnPath(graph, lockBranch);

            MathUtils.Shuffle(keyNodes, random);
            MathUtils.Shuffle(lockNodes, random);

            var traversal = graphQuery.Traversal;
            
            foreach (var keyNode in keyNodes)
            {
                foreach (var lockNode in lockNodes)
                {
                    
                    // Lock link list creation criteria
                    //     1. Get all lock node links that connect to other nodes in the same lock path
                    //     2. grab the rest of the links connected to the lock node
                    //     3. Filter out the ones that already have a lock on them
                    // Lock link selection criteria 
                    //     1. Make sure the key node is accessible from the entrance, after blocking off the selected lock link
                    //     2. Make sure lock node is not accessible from the entrance after blocking off the selected lock link

                    // Generate the lock link array
                    var lockNodeLinks = new List<FlowLayoutGraphTraversal.FNodeInfo>();
                    {
                        var allLockLinks = traversal.GetConnectedNodes(lockNode.nodeId);

                        var resultPrimary = new List<FlowLayoutGraphTraversal.FNodeInfo>();
                        var resultSecondary = new List<FlowLayoutGraphTraversal.FNodeInfo>();
                        
                        foreach (var connectionInfo in allLockLinks)
                        {
                            // Make sure this link doesn't already have a lock
                            var lockLink = graphQuery.GetLink(connectionInfo.LinkId);
                            if (lockLink == null || FlowLayoutGraphUtils.ContainsItem(lockLink.state.items, FlowGraphItemType.Lock))
                            {
                                continue;
                            }

                            var connectedNode = graphQuery.GetNode(connectionInfo.NodeId);
                            if (connectedNode != null)
                            {
                                if (connectedNode.pathName == lockBranch)
                                {
                                    resultPrimary.Add(connectionInfo);
                                }
                                else
                                {
                                    resultSecondary.Add(connectionInfo);
                                }
                            }
                        }
                        
                        MathUtils.Shuffle(resultPrimary, random);
                        lockNodeLinks.AddRange(resultPrimary);

                        MathUtils.Shuffle(resultSecondary, random);
                        lockNodeLinks.AddRange(resultSecondary);
                    }
                    
                    
                    // Select the first valid link from the list
                    foreach (var lockConnection in lockNodeLinks)
                    {
                        var lockLinkId = lockConnection.LinkId;
                        var lockLink = graphQuery.GetLink(lockLinkId);
                        if (lockLink == null)
                        {
                            continue;
                        }

                        // Check if this link belongs to the main path
                        //var lockedNodeIds = GetLockedNodesInPath(graphQuery, lockLink);
                        var lockedNodeIds = new DungeonUID[]{ lockLink.destination };

                        Func<FlowLayoutGraphTraversal.FNodeInfo, bool> canTraverse = 
                                (traverseInfo) => traverseInfo.LinkId != lockLinkId;
                        
                        // 1. Make sure the key node is accessible from the entrance, after blocking off the selected lock link
                        bool canReachKey = FlowLayoutGraphUtils.CanReachNode(graphQuery, entranceNode.nodeId, keyNode.nodeId, 
                            false, false, true, canTraverse);
                        if (canReachKey) {
                            // 2. Make sure lock node is not accessible from the entrance after blocking off the selected lock link
                            bool canReachLockedNode = false;
                            foreach (var lockedNodeId in lockedNodeIds)
                            {
                                bool reachable = FlowLayoutGraphUtils.CanReachNode(graphQuery, entranceNode.nodeId, lockedNodeId,
                                    false, false, true, canTraverse);
                                
                                if (reachable)
                                {
                                    canReachLockedNode = true;
                                    break;
                                }
                            }
                            
                            if (!canReachLockedNode) {
                                outKeyNode = keyNode;
                                outLockLink = lockLink;
                                errorMessage = "";
                                return true;
                            }
                        }
                    }
                }
            }
            
            outKeyNode = null;
            outLockLink = null;
            errorMessage = "Cannot find key-lock";
            return false;
        }
    }
}