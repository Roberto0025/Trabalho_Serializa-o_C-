namespace Trab
{
    public class Produto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return $"Codigo: {Codigo} - Descrição: {Descricao}";
        }

        /*
        public string JsonSerializar(Produto prod)
        {
            return JsonConvert.SerializeObject(prod);
        }

        public static Produto JsonDeserializar(string Json)
        {
            return JsonConvert.DeserializeObject<Produto>(Json);
        }
        */
    }
}
