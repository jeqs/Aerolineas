namespace Aerolineas.Services.Interfaces
{
    public interface IOutputPort<in TResponse>
    {
        void Handle(TResponse response);
    }
}
