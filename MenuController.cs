using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace lr1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // Метод для виведення меню
        [HttpGet]
        public IActionResult GetMenu()
        {
            return Ok(new
            {
                Menu = new[]
                {
                    new { Option = 1, Desc = "Вивести кількість слів у тексті 'Lorem ipsum'" },
                    new { Option = 2, Desc = "Порахувати математичну операцію" },
                    new { Option = 3, Desc = "Вийти" }
                }
            });
        }

        [HttpGet("{choice}")]
        public IActionResult SelectMenu(int choice, [FromQuery] double num1 = 0, [FromQuery] double num2 = 0, [FromQuery] string operation = "")
        {
            switch (choice)
            {
                case 1:
                    return WordCou1();
                case 2:
                    return Calx(num1, num2, operation);
                case 3:
                    return Ok("Вихід з меню.");
                default:
                    return BadRequest("Некоректний вибір. Виберіть 1, 2 або 3.");
            }
        }

        // Метод для підрахунку слів у файлі 
        private IActionResult WordCou1()
        {
            var text = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "lorem.txt"));
            return Ok(new { wordCount = text.Split().Length });
        }

        // Метод для виконання математичної операції
        private IActionResult Calx(double num1, double num2, string operation)
        {
            if (string.IsNullOrWhiteSpace(operation))
            {
                return BadRequest("Не вказано операцію. Доступні операції: add, subtract, multiply, divide.");
            }

            double result;
            switch (operation.ToLower())
            {
                case "add":
                    result = num1 + num2;
                    break;
                case "subtract":
                    result = num1 - num2;
                    break;
                case "multiply":
                    result = num1 * num2;
                    break;
                case "divide":
                    if (num2 == 0)
                        return BadRequest("Ділення на нуль не допускається.");
                    result = num1 / num2;
                    break;
                default:
                    return BadRequest("Невідома операція. Доступні операції: add, subtract, multiply, divide.");
            }

            return Ok(new { num1, num2, operation, result });
        }
    }
}