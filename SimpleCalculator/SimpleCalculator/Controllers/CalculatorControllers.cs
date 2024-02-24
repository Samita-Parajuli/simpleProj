using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.Models;

public class CalculatorController : Controller
{
    public IActionResult Index()
    {
        // Initialize a new instance of CalculatorModel with default values
        var model = new Calculator
        {
            Operand1 = 0, // Set default value for Operand1
            Operand2 = 0, // Set default value for Operand2
            Operator = '+', // Set default value for Operator
            Result = 0 // Set default value for Result
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Calculate(Calculator model)
    {
        switch (model.Operator)
        {
            case '+':
                model.Result = model.Operand1 + model.Operand2;
                break;
            case '-':
                model.Result = model.Operand1 - model.Operand2;
                break;
            case '*':
                model.Result = model.Operand1 * model.Operand2;
                break;
            case '/':
                if (model.Operand2 != 0)
                {
                    model.Result = model.Operand1 / model.Operand2;
                }
                else
                {
                    ModelState.AddModelError("Operand2", "Error: Cannot divide by zero!");
                    return View("Index", model);
                }
                break;
            default:
                ModelState.AddModelError("Operator", "Error: Invalid operator!");
                return View("Index", model);
        }
        return View("Index", model);
    }
}
