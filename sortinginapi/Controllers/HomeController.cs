using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace sortinginapi.Controllers
{
    [Route("api/Home")]
    public class HomeController : Controller
    {

        [HttpPost]
        
        public IActionResult Index([FromBody] int[] arr)
        {
            int temp = 0;
           for(int i=0;i<arr.Length-1;i++)
            {
                for(int j=0;j<arr.Length-1;j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j + 1] = temp;
                    }
                }
            }

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize(arr, opt);

            return Ok(strJson);
        }
    }
}
