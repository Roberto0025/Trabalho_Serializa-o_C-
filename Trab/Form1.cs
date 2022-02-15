using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trab.Criptografia;

namespace Trab
{
    public partial class Form1 : Form
    {
        Lista listaProdutos = new Lista()
            {
                new Produto { Codigo = "01", Descricao = "Cerveja" },
                new Produto { Codigo = "02", Descricao = "Carne" },
                new Produto { Codigo = "03", Descricao = "Carvão" },
                new Produto { Codigo = "04", Descricao = "Salada" },
                new Produto { Codigo = "05", Descricao = "Espeto" },
                new Produto { Codigo = "06", Descricao = "Pão de Alho" },
                new Produto { Codigo = "07", Descricao = "Linguiça" },
                new Produto { Codigo = "08", Descricao = "Sal" },
                new Produto { Codigo = "09", Descricao = "Arroz" },
                new Produto { Codigo = "10", Descricao = "Mandioca" },
            };
public Form1()
        {
            InitializeComponent();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var produto = new Produto();
            produto.Codigo = txtCodigo.Text;
            produto.Descricao = txtDescricao.Text;
            listaProdutos.Add(produto);
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            /*try
            {
                string ProdSerializadoJson = JsonConvert.SerializeObject(listaProdutos);
                string ProdCriptografado = CriptografiaMD5.CodificaSenha("teste123", ProdSerializadoJson);
                File.WriteAllText(@"C:\Users\Beto\Desktop\Nova pasta\Trab\Produto.json", ProdSerializadoJson);
                File.WriteAllText(@"C:\Users\Beto\Desktop\Nova pasta\Trab\Produto.crypt", ProdCriptografado);

                MessageBox.Show("Produto Salvo!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }*/
        }
        private void btnSeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                string ListProdSerializadoJson = JsonConvert.SerializeObject(listaProdutos, Formatting.Indented /*formatação texto*/);
                string ListProdCriptografado = CriptografiaMD5.CodificaSenha("teste123", ListProdSerializadoJson);
                File.WriteAllText(@"C:\Users\Beto\Desktop\ListaJson.json", ListProdSerializadoJson);
                File.WriteAllText(@"C:\Users\Beto\Desktop\ListaCrypt.crypt", ListProdCriptografado);
                MessageBox.Show("Lista Serializada!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }
        private void btnDeserializarLista_Click(object sender, EventArgs e)
        {
            try
            {
                string ListProdCriptografado = File.ReadAllText(@"C:\Users\Beto\Desktop\ListaCrypt.crypt");
                string ListProdDescriptografado = CriptografiaMD5.DecodificaSenha("teste123", ListProdCriptografado);
                File.WriteAllText(@"C:\Users\Beto\Desktop\ListaDeserializada.json", ListProdDescriptografado);
                MessageBox.Show("Lista Deserializada!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }
        private void btnCarregarLista_Click(object sender, EventArgs e)
        {
            /*
            string rota = @"C:\Users\Beto\Desktop\ListaDeserializada.json";
            FileStream fs = new FileStream(rota, FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();
            var list = (Lista)bf.Deserialize(fs);
            fs.Close();
            txtResultado.Text = list.ToString();
            */
            try
            {
                /*
                //AQUI FIZ COM GABIARRA NO CODIGO
                string json = File.ReadAllText(@"C:\Users\Beto\Desktop\ListaDeserializada.json");
                int gambi = json.Length;
                string GAMBIARRA = json.Insert(gambi, "]");
                Lista listProd = JsonConvert.DeserializeObject<Lista>(GAMBIARRA);
                */

                //AQUI FUI OBRIGADO A PEGAR A LISTA 1º JSON, POIS A DESERIALZADA TEM ERRO, FALTA ']' NO ARQUIVO
                string json = File.ReadAllText(@"C:\Users\Beto\Desktop\ListaJson.json");
                Lista listProd = JsonConvert.DeserializeObject<Lista>(json);

                //txtResultado.Text = String.Join(Environment.NewLine, listProd);

                //txtResultado.Text = string.Join("\r\n", listProd);

                txtResultado.Text = listProd.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha: " + ex.Message);
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            txtResultado.Text = string.Join("\r\n", listaProdutos);
        }
    }
}
