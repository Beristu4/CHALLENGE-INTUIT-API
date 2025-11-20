using CHALLENGE_INTUIT.Dtos;
using CHALLENGE_INTUIT.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CHALLENGE_INTUIT.Service
{
    public class ClientService
    {
        private readonly MyContext _myContext;
        public ClientService(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<List<GetAllDto>> GetAll()
        {
            try
            {
                var dtoMap = await _myContext.Clients
                    .AsNoTracking()
                    .Select(r => new GetAllDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Adress = r.Adress,
                        Cuit = r.Cuit,
                        DateOfBirth = r.DateOfBirth.HasValue ? r.DateOfBirth.Value.ToString("dd/MM/yyyy") : "",
                        Email = r.Email,
                        LastName = r.LastName,
                        Telephone = r.Telephone
                    })
                    .ToListAsync();

                return dtoMap;

            }
            catch (Exception ex)
            {

                throw new Exception($"Error al traer el listado de clientes: {ex.Message}", ex);
            }
        }

        public async Task<GetByIdDto> GetById(int id)
        {
            try
            {
                var dtoMapById = await _myContext.Clients
                    .AsNoTracking()
                    .Select(r => new GetByIdDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Adress = r.Adress,
                        Cuit = r.Cuit,
                        DateOfBirth = r.DateOfBirth,
                        Email = r.Email,
                        LastName = r.LastName,
                        Telephone = r.Telephone
                    })
                    .FirstOrDefaultAsync(c => c.Id == id);

                return dtoMapById;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error al traer el cliente por ID: {ex.Message}", ex);
            }
        }

        public async Task<Clients> Insert(CreateClientDto client)
        {
            try
            {
                await ValidateRegex(client.Cuit, client.Telephone, client.Email);

                var newClient = new Clients
                {
                    Name = client.Name,
                    Adress = client.Address,
                    Cuit = client.Cuit,
                    Email = client.Email,
                    LastName = client.LastName,
                    Telephone = client.Telephone,
                    DateOfBirth = client.DateOfBirth
                };

                _myContext.Clients.Add(newClient);
                await _myContext.SaveChangesAsync();

                return newClient;

            }catch(Exception ex)
            {
                throw new Exception($"Error al crear el cliente: {ex.Message}", ex);
            }
        }

        public async Task<List<GetSearchByNameDto>> Search(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Debe ingresar un nombre para que se pueda realizar la busqueda");
                }

                var clientByName = await _myContext.Clients
                    .AsNoTracking()
                    .Where(c => c.Name.Contains(name))
                    .Select(r => new GetSearchByNameDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Adress = r.Adress,
                        Cuit = r.Cuit,
                        DateOfBirth = r.DateOfBirth.HasValue ? r.DateOfBirth.Value.ToString("dd/MM/yyyy") : "",
                        Email = r.Email,
                        LastName = r.LastName,
                        Telephone = r.Telephone

                    }).ToListAsync();

                return clientByName;

            }catch(Exception ex)
            {
                throw new Exception($"Error al buscar por nombre: {ex.Message}", ex);
            }
        }

        public async Task<Clients> Update(UpdateClientDto client)
        {
            try
            {
                await ValidateRegex(client.Cuit, client.Telephone, client.Email);

                var clientUpdate = await _myContext.Clients
                    .FirstOrDefaultAsync(c => c.Id == client.Id);

                if(clientUpdate == null)
                {
                    throw new Exception($"No se encontre cliente {client.Id} para actualizar");
                }

                //Actualizamos los datos si se encuentra
                clientUpdate.Name = client.Name;
                clientUpdate.LastName = client.LastName;
                clientUpdate.Telephone = client.Telephone;
                clientUpdate.Email = client.Email;
                clientUpdate.DateOfBirth = client.DateOfBirth;
                clientUpdate.Cuit = client.Cuit;
                clientUpdate.Adress = client.Address;


                _myContext.Clients.Update(clientUpdate);
                await _myContext.SaveChangesAsync();

                return clientUpdate;


            }catch(Exception ex)
            {
                throw new Exception($"Error al actualiza cliente: {ex.Message}", ex);
            }
        }

        public Task ValidateRegex(string cuit, string telephone, string email)
        {
            if (!Regex.IsMatch(cuit, @"^\d{2}\d{8}\d{1}$"))
                throw new Exception("El CUIT debe tener 11 digitos");

            if (!Regex.IsMatch(telephone, @"^\+?\d{7,15}$"))
                throw new Exception("El teléfono debe contener entre 7 y 14 digitos solo numericos");

            if (!new EmailAddressAttribute().IsValid(email))
                throw new Exception("El formato del email no es válido");

            return Task.CompletedTask;
        }
    }
}
