using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Request;
using Shared.Models;
using VaquerSansPere.Backend.WebApi.Services;
using VaquerSansPere.Backend.WebApi.Services.Interfaces;

namespace VaquerSansPere.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumbersController : Controller
    {
       private readonly ITriangleArea _triangleArea;
       private readonly IOrderNumList _orderNumList;
       private readonly IGreatestNumList _greatestNumList;
       private readonly ILowestNumList _lowestNumList;
       private readonly IPrimeNumber _primeNumber;
       private readonly ICircleData _circleData;

        public NumbersController
            (
            ITriangleArea triangleArea, 
            IOrderNumList orderNumList, 
            IGreatestNumList greatestNumList, 
            ILowestNumList lowestNumList,
            IPrimeNumber primeNumber,
            ICircleData circleData
            ) 
        {
            _triangleArea = triangleArea;
            _orderNumList = orderNumList;
            _greatestNumList = greatestNumList;
            _lowestNumList = lowestNumList;
            _primeNumber = primeNumber;
            _circleData = circleData;
        }

        /// <summary>
        /// Shows a triangle area given its surface and height
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        [HttpPost("TriangleArea")]
        public IActionResult TriangleArea(TriangleRequest triangle) 
        {
            var res = _triangleArea.CalcTriangleArea(triangle);
            return Ok(new { Area=res });
        }

        /// <summary>
        /// Takes a number list and orders it from lowest to greatest
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("OrderNumList")]
        public IActionResult OrderNumList(List<int> list) 
        {
            var res = _orderNumList.OrderedNumList(list);
            return Ok(list);
        }

        /// <summary>
        /// Shows the area and perimeter of a circle given its radius
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        [HttpPost("CircleAreaPerimeter")]
        public IActionResult ShowAreaPerimeter(CircleRequest circle)
        {
            var CircleArea = _circleData.CalcCircleArea(circle);
            var CirclePerimeter = _circleData.CalcCirclePerimeter(circle);
            return Ok(new { CircleArea=CircleArea,CirclePerimeter=CirclePerimeter,Color=circle.Color });
        }

        /// <summary>
        /// Shows the greatest number from an integer list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("GreatestNumList")]
        public IActionResult GreatestNumList(List<int> list)
        {
            var res = _greatestNumList.GreatestValueList(list);
            return Ok(res);
        }

        /// <summary>
        /// Shows the lowest number from an integer list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("LowestNumList")]
        public IActionResult LowestNumList(List<int> list)
        {
            var res = _lowestNumList.LowestValueList(list);
            return Ok(res);
        }
        /// <summary>
        /// Tells whether a number is, or not, a prime number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpGet("IsPrime")]
        public IActionResult PrimeNumber(int num) 
        {
            var res = _primeNumber.IsPrimeNumber(num);
            return Ok(res);
        }
    }

}
