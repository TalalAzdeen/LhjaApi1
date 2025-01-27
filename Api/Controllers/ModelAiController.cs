using Api.Repositories;
using Api.ServiceLayer.LayerModel;
using ASG.Api2.Results;
using AutoMapper;
using Dto;
using Dto.ModelAi;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace ASG.Api2.Controllers
{




    [ApiController]
    [Route("api/[controller]")]
    //[OutputCache(PolicyName = "CustomPolicy", Tags = new[] { "Model Ai" })]



    public class ModelAiController(IModelAiRepository repository,IModelService modelService, IMapper mapper) : ControllerBase
    {
        [EndpointSummary("Get all Model Ai")]
        [HttpGet(Name = "GetModelsAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ModelAiResponse>>> GetAll()
        {
          //  var items = await repository.GetAllAsync();
            var items1 =   modelService.GetAllModels();
            var result = mapper.Map<List<ModelAiResponse>>(items1);
            //return Ok(new BaseResponseModel { Success = true, Data = data });
            return Ok(result);
        }


        /// <summary>
        /// ////////////////////////////////////////////////
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [EndpointSummary("Get Models By Category")]
        [HttpGet("category/{category}", Name = "GetModelsByCategory")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByCategory(string category)
        {
            var items = modelService.GetModelByCategory(category);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }
        [EndpointSummary("Get Models By Gender")]
        [HttpGet("gender/{gender}", Name = "GetModelsByGender")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByGender(string gender)
        {
            var items = modelService.GetModelByGender(gender);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        [EndpointSummary("Get Models By Dialect")]
        [HttpGet("dialect/{dialect}", Name = "GetModelsByDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByDialect(string dialect)
        {
            var items = modelService.GetModelByIsDialect(dialect);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        [EndpointSummary("Get Models By Language and Dialect")]
        [HttpGet("language-dialect", Name = "GetModelsByLanguageAndDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByLanguageAndDialect(string language, string dialect)
        {
            var items = modelService.GetModelByIsLanguageAndDialect(language, dialect);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        [EndpointSummary("Get Models By Language, Dialect, and Type")]
        [HttpGet("language-dialect-type", Name = "GetModelsByLanguageDialectType")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByLanguageDialectAndType(string language, string dialect, string type)
        {
            var items = modelService.GetModelByIsLanguageAndDialectAndType(language, dialect, type);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        [EndpointSummary("Get Models By IsStandard")]
        [HttpGet("is-standard/{isStandard}", Name = "GetModelsByIsStandard")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByIsStandard(string isStandard)
        {
            var items = modelService.GetModelByIsStandard(isStandard);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        [EndpointSummary("Get Models By Type and Gender")]
        [HttpGet("type-gender", Name = "GetModelsByTypeAndGender")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByTypeAndGender(string type, string gender)
        {
            var items = modelService.GetModelByIsTypeAndGender(type, gender);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }




        [EndpointSummary("Get Models By Language")]
        [HttpGet("language/{language}", Name = "GetModelsByLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ModelAiResponse>> GetByLanguage(string language)
        {
            var items = modelService.GetModelByLanguage(language);
            var result = mapper.Map<List<ModelAiResponse>>(items);
            return Ok(result);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [EndpointSummary("Get one")]
        [HttpGet("{id}", Name = "GetModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ModelAiResponse>> GetOne(string id)
        {
            var item = await repository.GetByAsync(m => m.Id == id);
            var result = mapper.Map<ModelAiResponse>(item);
            return Ok(result);
        }


        [EndpointSummary("Get Setting")]
        [HttpGet("{langage}", Name = "GetSettingModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetSettIng(string langage)
        {

            Dictionary<string, List<string>> propertyValues = null;
            if (langage == "en")
            {



               propertyValues = new Dictionary<string, List<string>>()
                                {
                                    { "UsageCount", new List<string> { "600","8888" } },
                                    { "ModelImageUrl", new List<string> { "/ai-hand.png", "/ai-robot.png", "chat-boat.jpg", "chatbot-cta.png" } },
                                    { "Type", new List<string> { "Text To Text", "Text To Speech", "Chat Model" } },
                                    { "Voice", new List<string> { "Male", "Female" } },
                                    { "Language", new List<string> { "English", "German", "Arabic" } },
                                    { "Dialect", new List<string> {"Najd","Hijazi"} },
                                    { "Quality", new List<string> { "High", "Medium", "Low" } },
                                    { "Token", new List<string> { "100", "500", "1000", "5000", "10000" } },
                                    { "ModelVersion", new List<string> { "v1.0", "v1.1", "v2.0", "v2.5", "v3.0" } },
                                    { "CreationDate", new List<string> { "2023-01-01", "2022-12-15", "2021-11-20" } },
                                    { "LastUpdated", new List<string> { "2023-12-01", "2023-11-15", "2023-10-30" } },
                                    { "Description", new List<string> { "Random generated description.", "High-quality model for tasks.", "Used in various applications." } },
                                    { "Author", new List<string> { "Heba  V1", "Heba  V2", "Heba  V3","BssamV1","BssamV2" } },
                                    { "Accuracy", new List<string> { "0.90", "0.85", "0.95" } },
                                    { "Speed", new List<string> { "Fast", "Medium", "Slow" } },
                                    { "Framework", new List<string> { "TensorFlow", "PyTorch", "Keras" } },
                                    { "Parameters", new List<string> { "1000000", "5000000", "10000000" } }
                                };



            }
            else
            {

             propertyValues = new Dictionary<string, List<string>>()
                                {
                                    { "UsageCount", new List<string> { "600", "8888" } },
                                    { "ModelImageUrl", new List<string> { "/ai-hand.png", "/ai-robot.png", "chat-boat.jpg", "chatbot-cta.png" } },
                                    { "Type", new List<string> { "نص إلى نص", "نص إلى كلام", "نموذج محادثة" } },
                                    { "Voice", new List<string> { "ذكر", "أنثى" } },
                                    { "Language", new List<string> { "إنجليزي","صيني" , "عربي" } },
                                    { "Dialect", new List<string> {  "نجدي","حجازي" } },
                                    { "Quality", new List<string> { "عالي", "متوسط", "منخفض" } },
                                    { "Token", new List<string> { "100", "500", "1000", "5000", "10000" } },
                                    { "ModelVersion", new List<string> { "v1.0", "v1.1", "v2.0", "v2.5", "v3.0" } },
                                    { "CreationDate", new List<string> { "2023-01-01", "2022-12-15", "2021-11-20" } },
                                    { "LastUpdated", new List<string> { "2023-12-01", "2023-11-15", "2023-10-30" } },
                                    { "Description", new List<string> { "وصف تم إنشاؤه عشوائيًا.", "نموذج عالي الجودة للمهام.", "يستخدم في العديد من التطبيقات." } },
                                    { "Author", new List<string> { "النموذج توليف 1", "النموذج توليف  2", "النموذج توليف 3" } },
                                    { "Accuracy", new List<string> { "0.90", "0.85", "0.95" } },
                                    { "Speed", new List<string> { "سريع", "متوسط", "بطيء" } },
                                    { "Framework", new List<string> { "TensorFlow", "PyTorch", "Keras" } },
                                    { "Parameters", new List<string> { "1000000", "5000000", "10000000" } }
                                };
    }
            return Ok(propertyValues);
        }



        [EndpointSummary("Create a Model Ai")]
        [HttpPost("CreateModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ModelAiResponse>> Create(ModelAiCreate model)
        {
            try
            {
                var item = mapper.Map<ModelAiCreate, ModelAi>(model);
                var result = await repository.CreateAsync(item);
                return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { Type = ex.GetType().FullName, Title = ex.Message, Detail = ex.InnerException?.Message });
            }
        }

        [EndpointSummary("Update Model Ai")]
        [HttpPut("{id}", Name = "UpdateModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ModelAiResponse>> Update(string id, ModelAiUpdate model)
        {
            try
            {
                var modelAi = await repository.GetByAsync(r => r.Id == id);
                if (modelAi == null)
                {
                    return NotFound(Result.NotFound("Item not found make sure that id is true"));
                }
                var item = mapper.Map<ModelAiUpdate, ModelAi>(model);
                item.Id = id;
                await repository.UpdateAsync(item);
                var result = mapper.Map<ModelAiResponse>(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(Result.Problem(ex));
            }
        }

        [EndpointSummary("Delete Model Ai")]
        [HttpDelete("{id}", Name = "DeleteModelAi")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletedResponse>> Delete(string id)
        {
            try
            {
                if (!await repository.Exists(p => p.Id == id))
                {
                    return NotFound($"Model Ai with id {id} not exists");
                }
                await repository.RemoveAsync(p => p.Id == id);
                return Ok(new DeletedResponse { Id = id, Deleted = true });
            }
            catch (Exception ex)
            {
                return BadRequest(Result.Problem(ex));
            }
        }
    }
}
