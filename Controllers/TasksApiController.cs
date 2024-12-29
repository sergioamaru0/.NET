using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DTO;
using TaskManager.Model;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksApiController : ControllerBase
    {
        private readonly IValidator<TaskModel> _validator;
        private readonly TaskServices _taskServices;

        public TasksApiController(TaskServices taskServices , IValidator<TaskModel> validator)
        {
            _taskServices = taskServices;
            _validator = validator;
        }
       

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks([FromQuery] bool? status)
        {
            try
            {
                if (status == null)
                {
                    var allTasks = await _taskServices.GetTasks();
                    return Ok(allTasks);
                }

                var filteredTasks = await _taskServices.GetTasksByStatus(status.Value);
                return Ok(filteredTasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Hubo un error interno al obtener las tareas.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet("{taskId:length(24)}", Name = "GetTaskId")]
        public async Task<ActionResult<TaskModel>> GetTaskId(string taskId)
        {
            try
            {
                var task = await _taskServices.GetTaskId(taskId);
                if (task == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        StatusCode = 404,
                        Message = "Tarea no encontrada.",
                        Details = $"No se encontró la tarea con ID: {taskId}."
                    });
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Hubo un error interno al obtener la tarea.",
                    Details = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTask(TaskModel task)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(task);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var taskCreate = await _taskServices.CreateTask(task);
                return CreatedAtRoute("GetTaskId", new { taskId = taskCreate.TaskId }, taskCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Hubo un error al crear la tarea.",
                    Details = ex.Message
                });
            }
        }

        [HttpPut("{taskId:length(24)}")]
        public async Task<IActionResult> UpdateTask(string taskId, TaskDto taskDto)
        {
            try
            {
                var task = await _taskServices.GetTaskId(taskId);
                if (task == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        StatusCode = 404,
                        Message = "Tarea no encontrada.",
                        Details = $"No se encontró la tarea con ID: {taskId}."
                    });
                }

                await _taskServices.UpdateTask(taskId, taskDto);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Hubo un error al actualizar la tarea.",
                    Details = ex.Message
                });
            }
        }

        [HttpDelete("{taskId:length(24)}")]
        public async Task<IActionResult> DeleteTask(string taskId)
        {
            try
            {
                var task = await _taskServices.GetTaskId(taskId);
                if (task == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        StatusCode = 404,
                        Message = "Tarea no encontrada.",
                        Details = $"No se encontró la tarea con ID: {taskId}."
                    });
                }

                await _taskServices.DeleteTask(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    StatusCode = 500,
                    Message = "Hubo un error al eliminar la tarea.",
                    Details = ex.Message
                });
            }
        }
    }
}
