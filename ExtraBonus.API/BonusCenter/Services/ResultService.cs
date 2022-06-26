using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;
using ExtraBonus.API.Shared.Domain.Repositories;

namespace ExtraBonus.API.BonusCenter.Services;

public class ResultService :IResultService
{
    
    private readonly IBondRepository _bondRepository;
    private readonly IResultRepository _resultRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ResultService(IBondRepository bondRepository, IResultRepository resultRepository, IUnitOfWork unitOfWork)
    {
        _bondRepository = bondRepository;
        _resultRepository = resultRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Result>> ListAsync()
    {
        return await  _resultRepository.ListAsync();
    }

    public async Task<IEnumerable<Result>> ListByBondIdAsync(int bondId)
    {
        return await _resultRepository.ListByBondIdAsync(bondId);
    }

    public async Task<Result> FindByIdAsync(int id)
    {
        return await _resultRepository.FindByIdAsync(id);
    }

    public async Task<ResultResponse> SaveAsync(Result result)
    {
        var existingBond = await _bondRepository.FindByIdAsync(result.BondId);
        
        if (existingBond == null)
            return new ResultResponse("bond not exist with this Result.");
        try
        {
            // Add Tutorial
            await _resultRepository.AddAsync(result);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new ResultResponse(result);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ResultResponse($"An error occurred while saving the new result: {e.Message}");
        }
    }

    public async Task<ResultResponse> UpdateAsync(int id, Result result)
    {
        var existingResult = await _resultRepository.FindByIdAsync(id);
        if (existingResult==null)
            return new ResultResponse("Invalid result or  not exist");
        

        // Modify Fields

        existingResult.Capitalizacion = result.Capitalizacion;
        existingResult.Cok = result.Cok;
        existingResult.Convexidad = result.Convexidad;
        existingResult.Duracion = result.Duracion;
        existingResult.Efectiva = result.Efectiva;
        existingResult.Frecuencia = result.Frecuencia;
        existingResult.Periodo = result.Periodo;
        existingResult.Total = result.Total;
        existingResult.Utilidad = result.Utilidad;
        existingResult.CostoEmisor = result.CostoEmisor;
        existingResult.CostoInversor = result.CostoInversor;
        existingResult.DuracionModif = result.DuracionModif;
        existingResult.EfectivaAnual = result.EfectivaAnual;
        existingResult.TotalPeriodo = result.TotalPeriodo;
        existingResult.Precio = result.Precio;
        existingResult.TCEAemisor = result.TCEAemisor;
        existingResult.TCEAemisorEscudo = result.TCEAemisorEscudo;
        existingResult.TREAbonista = result.TREAbonista;

        try
        {
            _resultRepository.Update(existingResult);
            await _unitOfWork.CompleteAsync();

            return new ResultResponse(existingResult);
            
        }
        catch (Exception e)
        {
            // Error Handling
                return new ResultResponse($"An error occurred while updating the Result: {e.Message}");
        }
    }

    public async Task<ResultResponse> DeleteAsync(int id)
    {
        var existingResult = await _resultRepository.FindByIdAsync(id);
        
        // Validate chat

        if (existingResult== null)
            return new ResultResponse("result not found.");
        
        try
        {
            _resultRepository.Remove(existingResult);
            await _unitOfWork.CompleteAsync();

            return new ResultResponse(existingResult);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ResultResponse($"An error occurred while deleting the Result: {e.Message}");
        }
    }
}