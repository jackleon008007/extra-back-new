using ExtraBonus.API.BonusCenter.Domain.Models;
using ExtraBonus.API.BonusCenter.Domain.Repositories;
using ExtraBonus.API.BonusCenter.Domain.Services;
using ExtraBonus.API.BonusCenter.Domain.Services.Comunication;
using ExtraBonus.API.Security.Domain.Repositories;
using ExtraBonus.API.Shared.Domain.Repositories;

namespace ExtraBonus.API.BonusCenter.Services;

public class BondService : IBondService
{
    private readonly IBondRepository _bondRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BondService(IBondRepository bondRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _bondRepository = bondRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<Bond>> ListAsync()
    {
        return await  _bondRepository.ListAsync();
    }

    public async Task<IEnumerable<Bond>> ListByUserIdAsync(int userId)
    {
        return await _bondRepository.ListByUserIdAsync(userId);
    }

    public async Task<Bond> FindByIdAsync(int id)
    {
        return await _bondRepository.FindByIdAsync(id);
    }

    public async Task<BondResponse> SaveAsync(Bond bond)
    {
        var existingUser = await _userRepository.FindByIdAsync(bond.UserId);
        
        if (existingUser == null)
            return new BondResponse("User not exist with this id.");
        try
        {
            // Add Tutorial
            await _bondRepository.AddAsync(bond);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new BondResponse(bond);

        }
        catch (Exception e)
        {
            // Error Handling
            return new BondResponse($"An error occurred while saving the new bond: {e.Message}");
        }
    }

    public async Task<BondResponse> UpdateAsync(int id, Bond bond)
    {
        
        
        var existingBond = await _bondRepository.FindByIdAsync(id);
        if (existingBond==null)
            return new BondResponse("Invalid User not exist");
        

        // Modify Fields

        existingBond.Anos = bond.Anos;
        existingBond.Capitalizacion = bond.Capitalizacion;
        existingBond.Cavali = bond.Cavali;
        existingBond.Colocacion = bond.Colocacion;
        existingBond.Comercial = bond.Comercial;
        existingBond.Descuento = bond.Descuento;
        existingBond.Dias = bond.Dias;
        existingBond.Estructuracion = bond.Estructuracion;
        existingBond.Fecha = bond.Fecha;
        existingBond.Flotacion = bond.Flotacion;
        existingBond.Frecuencia = bond.Frecuencia;
        existingBond.Interes = bond.Interes;
        existingBond.Nominal = bond.Nominal;
        existingBond.Prima = bond.Prima;
        existingBond.Renta = bond.Renta;
        existingBond.Tasa = bond.Tasa;
        
        try
        {
            _bondRepository.Update(existingBond);
            await _unitOfWork.CompleteAsync();

            return new BondResponse(existingBond);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new BondResponse($"An error occurred while updating the Bond: {e.Message}");
        }
    }

    public async Task<BondResponse> DeleteAsync(int id)
    {
        var existingBond = await _bondRepository.FindByIdAsync(id);
        
        // Validate chat

        if (existingBond== null)
            return new BondResponse("Bond not found.");
        
        try
        {
            _bondRepository.Remove(existingBond);
            await _unitOfWork.CompleteAsync();

            return new BondResponse(existingBond);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new BondResponse($"An error occurred while deleting the Bond: {e.Message}");
        }
    }
}