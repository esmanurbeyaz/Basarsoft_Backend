using Basarsoft1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private static List<Point> _pointList = new List<Point>(); //nesneleri tutan liste

        [HttpGet]
        public List<Point> GetAll() //tüm point listelerini dönderir
        {
            return _pointList;
        }


        [HttpPost]
        public Point Add(Point point) //point değil void de yapabilirdin
        {
            var _point = new Point()
            {
                Id = point.Id,
                Name = point.Name,
                PointX = point.PointX,
                PointY = point.PointY,
            };
            _pointList.Add(point);
            return _point;

        }

        [HttpGet("{id}")]
        public ActionResult<Point> GetById(int id)
        {
            var point = _pointList.FirstOrDefault(p => p.Id == id);
            if (point == null)
            {
                return NotFound();

            }
            return point;
        }



        [HttpPut("{id}")]
        public ActionResult Update(int id, Point updatedPoint)
        {
            var point = _pointList.FirstOrDefault(p => p.Id == id);
            if (point == null)
            {
                return NotFound();
            } 

            point.Name = updatedPoint.Name;
            point.PointX = updatedPoint.PointX;
            point.PointY = updatedPoint.PointY;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var point = _pointList.FirstOrDefault(point => point.Id == id);
            if (point == null)
            {
                return NotFound();
            }

           _pointList.Remove(point);
            return NoContent();

        }



    }



    
}
