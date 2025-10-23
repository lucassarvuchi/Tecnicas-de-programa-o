namespace reserva_de_sala_dsm.Interfaces
{
    public interface ISalaRepository
    {
        Task<IEnumerable<Models.Sala>> GetAllAsync();
        Task<Models.Sala> GetByIdAsync(long id);
        Task AddAsync(Models.Sala sala);
        void Update(Models.Sala sala);
        void Delete(Models.Sala sala);
        Task SaveChangesAsync();
    }
}
