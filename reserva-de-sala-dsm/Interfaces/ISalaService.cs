namespace reserva_de_sala_dsm.Interfaces
{
    public interface ISalaService
    {
        Task<IEnumerable<Models.Sala>> GetAllSalasAsync();
        Task<Models.Sala> GetSalaByIdAsync(long id);
        Task<Models.Sala> SaveSalaAsync(Models.Sala sala);
        Task DeleteSalaAsync(long id);
    }
}
