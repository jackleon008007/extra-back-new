using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;
using ExtraBonus.API.Shared.Domain.Repositories;

namespace ExtraBonus.API.BonusCenter.Services;

public class DueService : IDueService
{
    private readonly IBondRepository _bondRepository;
    private readonly IDueRepository _dueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DueService(IBondRepository bondRepository, IDueRepository dueRepository, IUnitOfWork unitOfWork)
    {
        _bondRepository = bondRepository;
        _dueRepository = dueRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Due>> ListAsync()
    {
        return await  _dueRepository.ListAsync();
    }

    public async Task<IEnumerable<Due>> ListByBondIdAsync(int bondId)
    {
        return await _dueRepository.ListByBondIdAsync(bondId);
    }

    public async Task<Due> FindByIdAsync(int id)
    {
        return await _dueRepository.FindByIdAsync(id);
    }

    public async Task<DueResponse> SaveAsync(Due due)
    {
        var existingBond = await _bondRepository.FindByIdAsync(due.BondId);
        
        if (existingBond == null)
            return new DueResponse("due not exist with this Bond.");
        try
        {
            // Add Tutorial
            await _dueRepository.AddAsync(due);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new DueResponse(due);

        }
        catch (Exception e)
        {
            // Error Handling
            return new DueResponse($"An error occurred while saving the new user: {e.Message}");
        }
    }

    public async Task<DueResponse> UpdateAsync(int id, Due due)
    {
        var existingDue = await _dueRepository.FindByIdAsync(id);
        if (existingDue==null)
            return new DueResponse("Invalid due or  not exist");
        

        // Modify Fields

        existingDue.Activo = due.Activo;
        existingDue.Amortizacion = due.Amortizacion;
        existingDue.Bonista = due.Bonista;
        existingDue.Bono = due.Bono;
        existingDue.Convexidad = due.Convexidad;
        existingDue.Cupon = due.Cupon;
        existingDue.Emisor = due.Emisor;
        existingDue.Escudo = due.Escudo;
        existingDue.Indexado = due.Indexado;
        existingDue.Inflacion = due.Inflacion;
        existingDue.Numero = due.Numero;
        existingDue.Plazo = due.Plazo;
        existingDue.Prima = due.Prima;
        existingDue.EmisorEscudo = due.EmisorEscudo;
        existingDue.InflacionPeriodo = due.InflacionPeriodo;
        //no estoy seguro si agregar el idcuota cuando se actualiza.

        try
        {
            _dueRepository.Update(existingDue);
            await _unitOfWork.CompleteAsync();

            return new DueResponse(existingDue);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new DueResponse($"An error occurred while updating the Due: {e.Message}");
        }
    }

    public async Task<DueResponse> DeleteAsync(int id)
    {
        var existingDue = await _dueRepository.FindByIdAsync(id);
        
        // Validate chat

        if (existingDue== null)
            return new DueResponse("Due not found.");
        
        try
        {
            _dueRepository.Remove(existingDue);
            await _unitOfWork.CompleteAsync();

            return new DueResponse(existingDue);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new DueResponse($"An error occurred while deleting the Bond: {e.Message}");
        }
    }
}