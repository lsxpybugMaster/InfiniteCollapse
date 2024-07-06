using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace GameMain.Scripts.Tools.Level_Manager
{
    public class StartConfigDrawer : MonoBehaviour
    {
        public StarConfig config;
        public Transform originalSpeedTrans;
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.Label(transform.position, $"{config.type.ToString()}: Appear Time {config.appearTime}" );
        }
        
        private void OnDrawGizmosSelected()
        {
            if (originalSpeedTrans == null)
            {
                return;
            }

            Gizmos.color = Color.red; // 设置箭头颜色为红色，可以根据需要调整颜色

            // 获取起点和终点的位置
            Vector3 fromPosition = transform.position;
            Vector3 toPosition = originalSpeedTrans.transform.position;

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