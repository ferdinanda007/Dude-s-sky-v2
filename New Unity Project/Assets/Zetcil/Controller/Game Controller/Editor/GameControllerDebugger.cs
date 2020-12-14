using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Zetcil
{
    public class GameControllerDebugger : EditorWindow
    {
        public const int BLACK = 0;
        public const int BLUE = 1;
        public const int TEAL = 1;
        public const int GREEN = 3;
        public const int ORANGE = 4;
        public const int YELLOW = 5;
        public const int RED = 6;
        public const int MODEL = 1;
        public const int VIEW = 2;
        public const int CONTROLLER = 3;

        private List<Node> nodes;
        private List<Connection> connections;

        private class CNodeStyle
        {
            public GUIStyle nodeStyle;
            public GUIStyle selectedNodeStyle;
            public GUIStyle inPointStyle;
            public GUIStyle outPointStyle;
            public void SetNodeStyle(int nodeIndex)
            {
                nodeStyle = new GUIStyle();
                nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node" + nodeIndex.ToString() + ".png") as Texture2D;
                nodeStyle.border = new RectOffset(12, 12, 12, 12);
                nodeStyle.alignment = TextAnchor.MiddleCenter;

                selectedNodeStyle = new GUIStyle();
                selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node" + nodeIndex.ToString() + " on.png") as Texture2D;
                selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);
                selectedNodeStyle.alignment = TextAnchor.MiddleCenter;

                if (nodeIndex == BLACK || nodeIndex == BLUE || nodeIndex == GREEN || nodeIndex == RED)
                {
                    nodeStyle.normal.textColor = Color.white;
                    selectedNodeStyle.normal.textColor = Color.white;
                }

                inPointStyle = new GUIStyle();
                inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
                inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
                inPointStyle.border = new RectOffset(4, 4, 12, 12);

                outPointStyle = new GUIStyle();
                outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
                outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
                outPointStyle.border = new RectOffset(4, 4, 12, 12);
            }
        }

        private GUIStyle nodeStyle;
        private GUIStyle selectedNodeStyle;
        private GUIStyle inPointStyle;
        private GUIStyle outPointStyle;

        private ConnectionPoint selectedInPoint;
        private ConnectionPoint selectedOutPoint;

        private Vector2 offset;
        private Vector2 drag;

        [MenuItem("Zetcil/Framework Debugger/Game Controller %F4", false, 6034)]
        private static void OpenWindow()
        {
            GameControllerDebugger window = GetWindow<GameControllerDebugger>();
            window.titleContent = new GUIContent("Framework Debugger");
        }

        private void RepaintDebugger()
        {
            nodes = null;

            CNodeStyle modelNodeStyle = new CNodeStyle();
            CNodeStyle viewNodeStyle = new CNodeStyle();
            CNodeStyle controllerNodeStyle = new CNodeStyle();

            if (nodes == null)
            {
                nodes = new List<Node>();
            }

            Vector2 modelPos = new Vector2(10, 10);
            Vector2 viewPos = new Vector2(260, 10);
            Vector2 controllerPos = new Vector2(510, 10);

            modelNodeStyle.SetNodeStyle(BLACK);
            Node modelNode = new Node(modelPos, 200, 50, modelNodeStyle.nodeStyle, modelNodeStyle.selectedNodeStyle, modelNodeStyle.inPointStyle, modelNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
            modelNode.title = "MODEL";
            nodes.Add(modelNode);

            viewNodeStyle.SetNodeStyle(BLACK);
            Node viewNode = new Node(viewPos, 200, 50, viewNodeStyle.nodeStyle, viewNodeStyle.selectedNodeStyle, viewNodeStyle.inPointStyle, viewNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
            viewNode.title = "VIEW";
            nodes.Add(viewNode);

            controllerNodeStyle.SetNodeStyle(BLACK);
            Node controllerNode = new Node(controllerPos, 200, 50, controllerNodeStyle.nodeStyle, controllerNodeStyle.selectedNodeStyle, controllerNodeStyle.inPointStyle, controllerNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
            controllerNode.title = "CONTROLLER";
            nodes.Add(controllerNode);

            foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            {
                CNodeStyle localNodeStyle = new CNodeStyle();
                int color_idx = BLACK;
                int object_status = MODEL;
                if (FunctionValidation(obj.gameObject, out color_idx, out object_status, modelPos, out modelPos, controllerPos, out controllerPos, viewPos, out viewPos))
                {
                    localNodeStyle.SetNodeStyle(color_idx);
                    if (object_status == MODEL)
                    {
                        Node tempNode = new Node(modelPos, 200, 50, localNodeStyle.nodeStyle, localNodeStyle.selectedNodeStyle, localNodeStyle.inPointStyle, localNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
                        tempNode.title = obj.name;
                        nodes.Add(tempNode);
                    }
                    else if (object_status == VIEW)
                    {
                        Node tempNode = new Node(viewPos, 200, 50, localNodeStyle.nodeStyle, localNodeStyle.selectedNodeStyle, localNodeStyle.inPointStyle, localNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
                        tempNode.title = obj.name;
                        nodes.Add(tempNode);
                    }
                    else if (object_status == CONTROLLER)
                    {
                        Node tempNode = new Node(controllerPos, 200, 50, localNodeStyle.nodeStyle, localNodeStyle.selectedNodeStyle, localNodeStyle.inPointStyle, localNodeStyle.outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode);
                        tempNode.title = obj.name;
                        nodes.Add(tempNode);
                    }
                }
            }
        }

        private void OnEnable()
        {
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node4.png") as Texture2D;
            nodeStyle.border = new RectOffset(12, 12, 12, 12);

            selectedNodeStyle = new GUIStyle();
            selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
            selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

            inPointStyle = new GUIStyle();
            inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
            inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
            inPointStyle.border = new RectOffset(4, 4, 12, 12);

            outPointStyle = new GUIStyle();
            outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
            outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
            outPointStyle.border = new RectOffset(4, 4, 12, 12);

            RepaintDebugger();
        }

        public bool FunctionValidation(GameObject targetObject, out int aColor, out int aObject, Vector2 aInMPos, out Vector2 aOutMPos, Vector2 aInCPos, out Vector2 aOutCPos, Vector2 aInVPos, out Vector2 aOutVPos)
        {
            bool result = false;
            float yOffset = 40;
            aColor = BLACK;
            aObject = MODEL;

            //-- MODEL Group
            if (targetObject.GetComponent<VarHealth>())
            {
                if (targetObject.GetComponent<VarHealth>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarMana>())
            {
                if (targetObject.GetComponent<VarMana>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarExp>())
            {
                if (targetObject.GetComponent<VarExp>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarScore>())
            {
                if (targetObject.GetComponent<VarScore>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarTime>())
            {
                if (targetObject.GetComponent<VarTime>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarInteger>())
            {
                if (targetObject.GetComponent<VarInteger>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarFloat>())
            {
                if (targetObject.GetComponent<VarFloat>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarBoolean>())
            {
                if (targetObject.GetComponent<VarBoolean>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarString>())
            {
                if (targetObject.GetComponent<VarString>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarObject>())
            {
                if (targetObject.GetComponent<VarObject>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarVector2>())
            {
                if (targetObject.GetComponent<VarVector2>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarVector3>())
            {
                if (targetObject.GetComponent<VarVector3>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarPointer>())
            {
                if (targetObject.GetComponent<VarPointer>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarPivot>())
            {
                if (targetObject.GetComponent<VarPivot>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarJSON>())
            {
                if (targetObject.GetComponent<VarJSON>().isEnabled) { aColor = GREEN; } else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarSyncronize>())
            {
                if (targetObject.GetComponent<VarSyncronize>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<VarSyncronize>().HealthVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().ManaVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().ExpVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().TimeVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().ScoreVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().IntegerVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().FloatVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().StringVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().BooleanVariables != null ||
                        targetObject.GetComponent<VarSyncronize>().ObjectVariables != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            else if (targetObject.GetComponent<VarRandom>())
            {
                if (targetObject.GetComponent<VarRandom>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<VarRandom>().RandomResult != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInMPos.y += yOffset; result = true;
                aObject = MODEL;
            }
            //-- CONTROLLER Group
            else if (targetObject.GetComponent<ActivationController>())
            {
                if (targetObject.GetComponent<ActivationController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<EventController>())
            {
                if (targetObject.GetComponent<EventController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<URLController>())
            {
                if (targetObject.GetComponent<URLController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<LevelController>())
            {
                if (targetObject.GetComponent<LevelController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<SceneController>())
            {
                if (targetObject.GetComponent<SceneController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<SpriteCollisionController>())
            {
                if (targetObject.GetComponent<SpriteCollisionController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<SpriteCollisionController>().TargetRigidbody2D != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<SpriteDraggableController>())
            {
                if (targetObject.GetComponent<SpriteDraggableController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<SpriteDraggableController>().MainCamera != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<CollisionController>())
            {
                if (targetObject.GetComponent<CollisionController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<CollisionController>().TargetRigidbody != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<DraggableController>())
            {
                if (targetObject.GetComponent<DraggableController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<DraggableController>().MainCamera != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<SpawnController>())
            {
                if (targetObject.GetComponent<SpawnController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<SpawnController>().TargetPrefab != null &&
                        targetObject.GetComponent<SpawnController>().TargetPosition != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<WaitController>())
            {
                if (targetObject.GetComponent<WaitController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<QuitController>())
            {
                if (targetObject.GetComponent<QuitController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<FlipFlopController>())
            {
                if (targetObject.GetComponent<FlipFlopController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<FadeController>())
            {
                if (targetObject.GetComponent<FadeController>().isEnabled)
                {
                    aColor = GREEN;
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<InstantiateController>())
            {
                if (targetObject.GetComponent<InstantiateController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<InstantiateController>().TargetPrefab != null &&
                        targetObject.GetComponent<InstantiateController>().TargetPosition != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }
            else if (targetObject.GetComponent<CreateController>())
            {
                if (targetObject.GetComponent<CreateController>().isEnabled)
                {
                    aColor = ORANGE;
                    if (targetObject.GetComponent<CreateController>().TargetPrefab != null &&
                        targetObject.GetComponent<CreateController>().TargetPosition != null)
                    {
                        aColor = GREEN;
                    }
                }
                else { aColor = RED; }
                aInCPos.y += yOffset; result = true;
                aObject = CONTROLLER;
            }

            aOutMPos = aInMPos;
            aOutCPos = aInCPos;
            aOutVPos = aInVPos;

            return result;
        }

        private void OnGUI()
        {
            DrawGrid(20, 0.2f, Color.gray);
            DrawGrid(100, 0.4f, Color.gray);

            DrawNodes();
            DrawConnections();

            DrawConnectionLine(Event.current);

            ProcessNodeEvents(Event.current);
            ProcessEvents(Event.current);

            if (GUI.changed) Repaint();
        }

        private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
        {
            int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
            int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

            Handles.BeginGUI();
            Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

            offset += drag * 0.5f;
            Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

            for (int i = 0; i < widthDivs; i++)
            {
                Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
            }

            for (int j = 0; j < heightDivs; j++)
            {
                Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
            }

            Handles.color = Color.white;
            Handles.EndGUI();
        }

        private void DrawNodes()
        {
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].Draw();
                }
            }
        }

        private void DrawConnections()
        {
            if (connections != null)
            {
                for (int i = 0; i < connections.Count; i++)
                {
                    connections[i].Draw();
                }
            }
        }

        private void ProcessEvents(Event e)
        {
            drag = Vector2.zero;

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        ClearConnectionSelection();
                    }

                    if (e.button == 1)
                    {
                        ProcessContextMenu(e.mousePosition);
                    }
                    break;

                case EventType.MouseDrag:
                    if (e.button == 0)
                    {
                        OnDrag(e.delta);
                    }
                    break;
            }
        }

        private void ProcessNodeEvents(Event e)
        {
            if (nodes != null)
            {
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    bool guiChanged = nodes[i].ProcessEvents(e);

                    if (guiChanged)
                    {
                        GUI.changed = true;
                    }
                }
            }
        }

        private void DrawConnectionLine(Event e)
        {
            if (selectedInPoint != null && selectedOutPoint == null)
            {
                Handles.DrawBezier(
                    selectedInPoint.rect.center,
                    e.mousePosition,
                    selectedInPoint.rect.center + Vector2.left * 50f,
                    e.mousePosition - Vector2.left * 50f,
                    Color.white,
                    null,
                    2f
                );

                GUI.changed = true;
            }

            if (selectedOutPoint != null && selectedInPoint == null)
            {
                Handles.DrawBezier(
                    selectedOutPoint.rect.center,
                    e.mousePosition,
                    selectedOutPoint.rect.center - Vector2.left * 50f,
                    e.mousePosition + Vector2.left * 50f,
                    Color.white,
                    null,
                    2f
                );

                GUI.changed = true;
            }
        }

        private void ProcessContextMenu(Vector2 mousePosition)
        {
            // off menu
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Refresh"), false, () => RepaintDebugger());
            genericMenu.ShowAsContext();
        }

        private void OnDrag(Vector2 delta)
        {

            drag = delta;

            // off drag
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].Drag(delta);
                }
            }

            GUI.changed = true;
        }

        private void OnClickAddNode(Vector2 mousePosition)
        {
            if (nodes == null)
            {
                nodes = new List<Node>();
            }

            nodes.Add(new Node(mousePosition, 200, 50, nodeStyle, selectedNodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint, OnClickRemoveNode));
        }

        private void OnClickInPoint(ConnectionPoint inPoint)
        {
            selectedInPoint = inPoint;

            if (selectedOutPoint != null)
            {
                if (selectedOutPoint.node != selectedInPoint.node)
                {
                    CreateConnection();
                    ClearConnectionSelection();
                }
                else
                {
                    ClearConnectionSelection();
                }
            }
        }

        private void OnClickOutPoint(ConnectionPoint outPoint)
        {
            selectedOutPoint = outPoint;

            if (selectedInPoint != null)
            {
                if (selectedOutPoint.node != selectedInPoint.node)
                {
                    CreateConnection();
                    ClearConnectionSelection();
                }
                else
                {
                    ClearConnectionSelection();
                }
            }
        }

        private void OnClickRemoveNode(Node node)
        {
            if (connections != null)
            {
                List<Connection> connectionsToRemove = new List<Connection>();

                for (int i = 0; i < connections.Count; i++)
                {
                    if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
                    {
                        connectionsToRemove.Add(connections[i]);
                    }
                }

                for (int i = 0; i < connectionsToRemove.Count; i++)
                {
                    connections.Remove(connectionsToRemove[i]);
                }

                connectionsToRemove = null;
            }

            nodes.Remove(node);
        }

        private void OnClickRemoveConnection(Connection connection)
        {
            connections.Remove(connection);
        }

        private void CreateConnection()
        {
            if (connections == null)
            {
                connections = new List<Connection>();
            }

            connections.Add(new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
        }

        private void ClearConnectionSelection()
        {
            selectedInPoint = null;
            selectedOutPoint = null;
        }
    }
}