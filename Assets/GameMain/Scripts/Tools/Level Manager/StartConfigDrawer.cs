using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace GameMain.Scripts.Tools.Level_Manager
{
    public class StartConfigDrawer : MonoBehaviour
    {
        public StarConfig config;
        public Transform fromPoint;
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter; // 设置文本居中对齐
            
            Handles.Label(fromPoint.position, $"{config.type.ToString()}: Appear Time {config.appearTime}", style);
        }
        
        private void OnDrawGizmosSelected()
        {
            if (fromPoint == null)
            {
                return;
            }

            Gizmos.color = Color.red; // 设置箭头颜色为红色，可以根据需要调整颜色

            // 获取起点和终点的位置
            Vector3 fromPosition = fromPoint.transform.position;
            Vector3 toPosition = transform.position;

            // 计算箭头的方向向量
            Vector3 direction = toPosition - fromPosition;

            // 绘制箭头的线段部分
            Gizmos.DrawLine(fromPosition, toPosition);

            // 绘制箭头的三角形部分
            float arrowSize = 0.5f; // 箭头的大小，可以根据需要调整
            Vector3 right = Quaternion.Euler(0, 0, 135) * direction.normalized * arrowSize;
            Vector3 left = Quaternion.Euler(0, 0, -135) * direction.normalized * arrowSize;

            Gizmos.DrawRay(toPosition, right);
            Gizmos.DrawRay(toPosition, left);
        }
#endif
    }
}