using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DivisibleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisibleController : ControllerBase
    {
        [HttpGet]
        [Route("GetVersion")]
        public string GetVersion()
        {
            return "TestVersion";
        }

        [HttpPost]
        [Route("IsNumberDiv")]
        public IActionResult IsNumberDivisible(string InputStr)
        {
			var list = InputStr.Trim(new Char[] { '[', ']' }).Split(',');
            List<string> jsonList = new List<string>();
            foreach (string obj in list)
            {
                try
                {
                    var number = int.Parse(obj);
                    string result = string.Empty;
                    string result2 = string.Empty;
                    string result3 = string.Empty;
                    if (number % 3 == 0)
                    {
                        result = "Fizz";
                    }
                    else
                    {
                        result2 = "Divided " + number + " by 3";
                    }
                    if (number % 5 == 0)
                    {
                        result += "Buzz";
                    }
                    else
                    {
                        result3 = "Divided " + number + " by 5";
                    }
                    if (!string.IsNullOrEmpty(result)) jsonList.Add(result);
                    if (string.IsNullOrEmpty(result))
                    {
                        jsonList.Add(result2);
                        jsonList.Add(result3);
                    }
                    
                }
                catch (Exception e)
                {
                    jsonList.Add("Invalid Item");
                }
            }
            return jsonList.Any() ? (IActionResult) Ok(jsonList):NotFound(jsonList);
        }

    }
}
