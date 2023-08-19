namespace Proyecto_Cl2_Maribel.Models
{
    public interface IPostulante
    {
        // Interface : donde definimos los metodos pero no los
        //estamos implementando
        IEnumerable<Postulante> GetPostulantes();

        string Agregar(Postulante postulante);
        string Editar(Postulante postulante);
        string Delete(Postulante postulante);
    }
}
