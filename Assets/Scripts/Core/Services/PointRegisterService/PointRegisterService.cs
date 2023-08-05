using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using UnityEngine;

namespace Core.Services.PointRegisterService
{
    public class PointRegisterService : IPointRegisterService
    {
        private List<PointData> _points = new List<PointData>();

        public void RegisterSpawnPoint(Enumenators.PointType pointType, Transform pointTransform)
        {
            _points.Add(new PointData() {PointTransform = pointTransform, PointType = pointType});
        }

        public Transform[] GetAllPointByType(Enumenators.PointType pointType)
        {
            return _points.Where(element => element.PointType == pointType).Select(e => e.PointTransform).ToArray();
        }

        #region InnerClass

        private class PointData
        {
            public Transform PointTransform;
            public Enumenators.PointType PointType;
        }

        #endregion
    }
}