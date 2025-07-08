using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beginor.AppFx.Api;
using Beginor.AppFx.Core;
using Beginor.MiniApi.Models;
using Beginor.MiniApi.Data.Repositories;

namespace Beginor.MiniApi.Api.Controllers;

/// <summary>Table, cities 服务接口</summary>
[ApiController]
[Route("api/cities")]
public class CityController(
    ILogger<CityController> logger,
    ICityRepository repository
) : Controller {

    /// <summary>搜索 Table, cities , 分页返回结果</summary>
    /// <response code="200">成功, 分页返回结果</response>
    /// <response code="400">客户端发送错误请求</response>
    /// <response code="500">服务器内部错误</response>
    [HttpGet("")]
    [Authorize("cities.read")]
    public async Task<ActionResult<PaginatedResponseModel<CityModel>>> Search(
        [FromQuery] CitySearchModel model,
        CancellationToken token
    ) {
        try {
            var result = await repository.SearchAsync(model, token);
            return result;
        }
        catch (InvalidOperationException ex) {
            logger.LogError(ex.GetOriginalMessage());
            return BadRequest();
        }
        catch (Exception ex) {
            logger.LogError(ex, $"Can not search cities with {model.ToJson()} .");
            return this.InternalServerError(ex);
        }
    }

    /// <summary>获取指定的 Table, cities</summary>
    /// <response code="200">返回 Table, cities 信息</response>
    /// <response code="400">客户端发送错误请求</response>
    /// <response code="500">服务器内部错误</response>
    [HttpGet("{id:long}")]
    [Authorize("cities.read_by_id")]
    public async Task<ActionResult<CityModel>> GetById(
        long id,
        CancellationToken token
    ) {
        try {
            var result = await repository.GetByIdAsync(id, token);
            if (result == null) {
                return NotFound();
            }
            return result;
        }
        catch (InvalidOperationException ex) {
            logger.LogError(ex.GetOriginalMessage());
            return BadRequest();
        }
        catch (Exception ex) {
            logger.LogError(ex, $"Can not get cities by id {id}.");
            return this.InternalServerError(ex);
        }
    }

    /// <summary> 创建 Table, cities </summary>
    /// <response code="200">创建 Table, cities 成功</response>
    /// <response code="400">客户端发送错误请求</response>
    /// <response code="500">服务器内部错误</response>
    [HttpPost("")]
    [Authorize("cities.create")]
    public async Task<ActionResult<CityModel>> Create(
        [FromBody] CityModel model,
        CancellationToken token
    ) {
        try {
            await repository.SaveAsync(model, token);
            return model;
        }
        catch (InvalidOperationException ex) {
            logger.LogError(ex.GetOriginalMessage());
            return BadRequest();
        }
        catch (Exception ex) {
            logger.LogError(ex, $"Can not save {model.ToJson()} to cities.");
            return this.InternalServerError(ex);
        }
    }

    /// <summary>
    /// 更新 Table, cities
    /// </summary>
    /// <response code="200">更新成功，返回 Table, cities 信息</response>
    /// <response code="400">客户端发送错误请求</response>
    /// <response code="500">服务器内部错误</response>
    [HttpPut("{id:long}")]
    [Authorize("cities.update")]
    public async Task<ActionResult<CityModel>> Update(
        [FromRoute] long id,
        [FromBody] CityModel model,
        CancellationToken token
    ) {
        try {
            await repository.UpdateAsync(id, model, token);
            return model;
        }
        catch (InvalidOperationException ex) {
            logger.LogError(ex.GetOriginalMessage());
            return BadRequest();
        }
        catch (Exception ex) {
            logger.LogError(ex, $"Can not update cities by id {id} with {model.ToJson()} .");
            return this.InternalServerError(ex);
        }
    }

    /// <summary>删除 Table, cities </summary>
    /// <response code="204">删除 Table, cities 成功</response>
    /// <response code="400">客户端发送错误请求</response>
    /// <response code="500">服务器内部错误</response>
    [HttpDelete("{id:long}")]
    [ProducesResponseType(204)]
    [Authorize("cities.delete")]
    public async Task<ActionResult> Delete(
        long id,
        CancellationToken token
    ) {
        try {
            await repository.DeleteAsync(id, token);
            return NoContent();
        }
        catch (InvalidOperationException ex) {
            logger.LogError(ex.GetOriginalMessage());
            return BadRequest();
        }
        catch (Exception ex) {
            logger.LogError(ex, $"Can not delete cities by id {id} .");
            return this.InternalServerError(ex);
        }
    }

}
