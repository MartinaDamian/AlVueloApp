namespace AlVueloMobile.Models;

public class PlatoDto
{
    public int id { get; set; }
    public string nombre { get; set; } = "";
    public string ingredientes { get; set; } = "";
    public decimal precio { get; set; }
    public bool disponibilidad { get; set; }
    public string imagen_url { get; set; } = "";
    public int menu_id { get; set; }
}
