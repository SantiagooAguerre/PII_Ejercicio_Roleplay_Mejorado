namespace roleplay;

public interface ISanador : ISeresMagicos
{
    public void Curacion(int curar, IPersonajeBueno personajequecurar);
}