using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contas.Entidades;

namespace Contas
{
    class Program
    {
        #region DOC
        //RENATO DOMINGUES
        //20/05/2019
        //TESTE
        #endregion

        #region Declaração de Objetos
        //Definição da expressão para tratativas
        public static object IIf(bool expression, object truePart, object falsePart)
        { return expression ? truePart : falsePart; }
        #endregion

        #region Declaração de listas
        //Lista estática de clientes
        private static List<Clientes> lstClientes = new List<Clientes>();
        #endregion

        #region Delcaração de entidades
        //Entidade clientes
        public static Clientes clies = new Clientes();
        #endregion

        #region Declaração de variáveis
        static bool Poupanca = false;
        static bool Corrente = false;
        static int countClientes = 0;
        static int ID_Clie;
        static bool duplicada = false;
        static bool cadastrado = false;
        //static int menuOpcao = 0;
        #endregion

        #region MÉTODOS
        #region MAIN
        static void Main(string[] args)
        {
            //Declarando variáveis
            string nome = "";
            string CPF = "";
            string[] Email = new string[0];
            int nEmails = 0;
            string Dinheiro = "0";
            //string.Format("{0,12:C2}", Console.ReadLine());

            //Opção menu
            int opcao = 0;

            inicio:

            //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("***********CADASTRO DE CONTAS***********");
            Console.WriteLine("1 - Cadastro de conta corrente");
            Console.WriteLine("2 - Cadastro de conta poupança");

            //Se houver cliente cadastrado mostra a próxima opção
            if (lstClientes.Count > 0)
            {
                Console.WriteLine("3 - Consultar");
            }

            Console.WriteLine("");
            Console.Write("Entre com as opções: ");
            opcao = Convert.ToInt32(Console.ReadLine());
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Se for = 1 entra no cadastro de conta corrente
            if (opcao == 1)
            {
                Corrente = true;
                Console.Clear();
                CadInfoEntidades(nome, CPF, Email, nEmails, Dinheiro);
                goto inicio;
            }
            //Se for = 2 entra no cadastro de conta poupança
            else if (opcao == 2)
            {
                Poupanca = true;
                Console.Clear();
                CadInfoEntidades(nome, CPF, Email, nEmails, Dinheiro);
                goto inicio;
            }
            //Somente aparecerá a opção se houver já um cliente cadastrado
            else if(opcao == 3)
            {
                SelecionarCliente();
                goto inicio;
                
            }
            else
            {
                //Tratativa de opções
                Console.Clear();
                Console.WriteLine("Opção não existente!");
                Console.WriteLine("");
                goto inicio;
            }
        }
        #endregion

        #region CadInfoEntidades
        private static void CadInfoEntidades(string p_nome, string p_CPF, string[] p_email, int p_nEmails, string p_dinheiro)
        {
            //Delcaração de variáveis
            int opcao = 0;
            bool noEmail = false;

            cad:

            //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("***********CADASTRO DE CONTAS***********");
            Console.WriteLine("---Cadastro de Cliente" + IIf(Corrente, "/Conta corrente", "/Conta poupança"));

            Console.WriteLine("");
            Console.WriteLine("1 - Voltar");
            Console.WriteLine("2 - Continuar");

            Console.WriteLine("");
            Console.Write("Selecione a opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //Continua cadastro
            if (opcao == 2)
            {
                //INPUTS
                Console.WriteLine("");
                Console.Write("Nome: ");
                p_nome = Console.ReadLine();

                Console.WriteLine("");
                Console.Write("CPF: ");
                p_CPF = Console.ReadLine();

                //Chama método para retorno de duplicidade
                VerificaDuplicidade(p_CPF);

                //Se o usuário ainda não está cadastrado -> Aparece as linhas abaixo
                if (!cadastrado)
                {
                    Console.WriteLine("");
                    Console.Write("Dinheiro: ");
                    p_dinheiro = Console.ReadLine();

                    Console.WriteLine("");
                    Console.Write("Gostaria de cadastrar quantos e-mails? ");
                    p_nEmails = Convert.ToInt32(Console.ReadLine());
                }
                //Se estiver cadastrado, não informar os dados novamente
                else
                {
                    p_dinheiro = IIf(string.IsNullOrEmpty(p_dinheiro), "", p_dinheiro).ToString();
                    noEmail = true;
                }
                
                //Se o número de e-mails for > 0
                if (p_nEmails > 0)
                {
                    //Redimenciona o vetor para o número de e-mails inserido
                    p_email = new string[p_nEmails];

                    Console.WriteLine("");
                    Console.WriteLine("Digite os e-mails desejados: ");
                    for (int i = 0; i < p_email.Length; i++)
                    {
                        Console.Write("");
                        //Insere emails no vetor
                        p_email[i] = Console.ReadLine();
                    }
                }
                //Se o cliente estiver já cadastrado na lista o p_nEmails = 0
                else
                {
                    //Se tiver cadastrado não precisa informar email novamente
                    if (!noEmail)
                    {
                        Console.Clear();
                        Console.WriteLine("Precisa de pelo menos 1 e-mail ou mais!");
                        Console.WriteLine("");
                        goto cad;
                    }
                    
                }

                //Inicia a segunda verificação de duplicidade para pegar CPF duplicado
                if (VerificaDuplicidade(p_CPF))
                {
                    //Se houver clientes duplicados
                    if (ID_Clie >= 0 && lstClientes.Count > 0)
                    {
                        if (lstClientes[ID_Clie].corrente && lstClientes[ID_Clie].poupanca && !duplicada)
                        {
                            Console.Clear();
                            Console.WriteLine("Cadastrado com sucesso!");
                            Console.WriteLine("");
                            duplicada = true;
                        }
                        else
                        {
                            //Se a opção selecionada foi conta corrente
                            if (Corrente)
                            {
                                //Se o cliente possui conta corrente...
                                if (lstClientes[ID_Clie].corrente)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Já existe conta para este CPF!");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    //Seta valor à lista se o cliente não possui conta corrente
                                    lstClientes[ID_Clie].corrente = Corrente;
                                }

                            }
                            //Se a opção selecionada foi conta poupança
                            else if (Poupanca)
                            {
                                //Se o cliente possui conta poupança...
                                if (lstClientes[ID_Clie].poupanca)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Já existe conta para este CPF!");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    //Seta valor à lista se o cliente não possui conta poupança
                                    lstClientes[ID_Clie].poupanca = Poupanca;
                                }
                            }
                        }
                        

                    }

                }
                //Se não houver duplicidade adiciona à entidade e à lista
                else
                {
                    //Seta valor para entidade
                    clies = new Clientes();
                    clies.ID = countClientes;
                    clies.Nome = p_nome;
                    clies.CPF = p_CPF;
                    clies.dinheiro = Convert.ToDouble(p_dinheiro);
                    IIf(Corrente, clies.corrente = Corrente, clies.poupanca = Poupanca);
                    clies.email = new string[p_nEmails];

                    //Adiciona os emails
                    for (int i = 0; i < p_email.Length; i++)
                    {
                        clies.email[i] = p_email[i];
                    }

                    //Adiciona entidade à lista
                    lstClientes.Add(clies);
                    countClientes++;

                    //Mostra Msg
                    Console.Clear();
                    Console.WriteLine("Cadastrado com sucesso!");
                    Console.WriteLine("");
                    
                }

                //Seta variáveis para valor inicial
                Corrente = false;
                Poupanca = false;
                noEmail = false;
                cadastrado = false;
            }
            //Se não houver a opção digitada...
            else
            {
                Console.Clear();
                return;
            }


        }
#endregion

        #region VerificaDuplicidade
        private static bool VerificaDuplicidade(string p_CPF)
        {
            //Se houver clientes na lista
            if (lstClientes.Count > 0)
            {
                //Procura cliente já cadastrado de acordo com o CPF
                for (int i = 0; i < lstClientes.Count; i++)
                {
                    //Se o CPF digitado for igual à algum da lista
                    if (lstClientes[i].CPF == p_CPF)
                    {
                        //Seta variável para indicar que já está cadastrado.
                        cadastrado = true;

                        //Se a opção selecionada foi conta Corrente
                        if (Corrente)
                        {
                            //Pega informação da lista do cliente selecionado
                            if (lstClientes[i].corrente)
                            {
                                return true;
                            }
                            else
                            {
                                //Seta valor na lista de acordo com o cliente selecionado
                                lstClientes[ID_Clie].corrente = Corrente;
                                //Pega o ID
                                ID_Clie = lstClientes[i].ID;
                                return true;
                            }
                        }

                        //Se a opção selecionada foi conta Poupança
                        if (Poupanca)
                        {
                            //Pega informação da lista do cliente selecionado
                            if (lstClientes[i].poupanca)
                            {
                                return true;
                            }
                            else
                            {
                                //Seta valor na lista de acordo com o cliente selecionado
                                lstClientes[ID_Clie].poupanca = Poupanca;
                                //Pega o ID
                                ID_Clie = lstClientes[i].ID;
                                return true;
                            }
                        }

                    }

                }

                return false;
            }
            else
            {
                return false;
            }
            
        }
        #endregion

        #region SelecionaCliente
        private static void SelecionarCliente()
        { 
            //Declaração de variáveis
            int opcao = 0;

            //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < lstClientes.Count; i++)
            {
                //Mostra todos os clientes cadastrados da lista
                Console.WriteLine("");
                Console.WriteLine(i + " - " + lstClientes[i].Nome + ", CPF: " + lstClientes[i].CPF);
                Console.WriteLine("");
            }
            
            //Selecionar cliente
            Console.Write("Selecione um cliente: ");
            opcao = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            //Chama Menu para ações
            MenuCliente(opcao);

            //////////////////////////////////////////////////////////////////////////////////////////////////
        }
        #endregion

        #region MenuCliente
        private static void MenuCliente(int id)
        {
            //Declaração de variáveis
            int opcao = 0;
            string valor = "0";
            //Variáveis que verifica se o cliente possui uma determinada conta
            bool cCorrente = false;
            bool cPoupanca = false;

            //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");

            Console.WriteLine("");

            //Verifica se o cliente possui a conta
            if (lstClientes[ID_Clie].corrente)
            {
                Console.WriteLine("1 - Depósito para conta corrente");
            }
            else
            {
                Console.WriteLine("1 - Cliente não possui conta corrente");
                cCorrente = true;
            }

            //Verifica se o cliente possui a conta
            if (lstClientes[ID_Clie].poupanca)
            {
                Console.WriteLine("2 - Depósito para conta poupança");
            }
            else
            {
                Console.WriteLine("2 - Cliente não possui conta poupança");
                cPoupanca = true;
            }

            Console.WriteLine("3 - Saque");
            Console.WriteLine("4 - Voltar");

            //Selecione a opção
            Console.WriteLine("");
            Console.Write("Selecione a opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            //Verifica se selecionou conta corrente e se houver conta corrente
            if (opcao == 1 && !cCorrente)
            {
                //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
                Console.Clear();
                Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");
                Console.WriteLine("---ADMIN" + "/Depósito para conta corrente");

                Console.WriteLine("");
                Console.WriteLine("Saldo atual conta corrente: " + lstClientes[id].depCorrente.ToString());
                Console.WriteLine("Dinheiro à aplicar: " + lstClientes[id].dinheiro.ToString());

                Console.WriteLine("");
                Console.Write("Digite o valor desejado: ");
                valor = Console.ReadLine();
                ///////////////////////////////////////////////////////////////////////////////////////////////////

                //SE O VALOR NÃO FOR NEGATIVO E O DINHEIRO DO CLIENTE FOR >= O VALOR DIGITADO
                if (valor.Substring(0, 1) != "-" && lstClientes[id].dinheiro >= Convert.ToDouble(valor))
                {
                    //REALIZA DEPÓSITO
                    lstClientes[id].depCorrente += Convert.ToDouble(valor);
                    lstClientes[id].dinheiro -= Convert.ToDouble(valor);

                    //Mostra valor adicionado
                    Console.Clear();
                    Console.WriteLine("O valor de " + valor + " adicionado na conta corrente!");
                    Console.WriteLine("");
                }
                else
                {
                    //Mostra Erro
                    Console.Clear();
                    Console.WriteLine("O valor não pode ser negativo!");
                    Console.WriteLine("");
                }

                
            }
            //Verifica se selecionou conta poupança e se houver conta poupança
            else if (opcao == 2 && !cPoupanca)
            {
                //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
                Console.Clear();
                Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");
                Console.WriteLine("---ADMIN" + "/Depósito para conta poupança");

                Console.WriteLine("");
                Console.WriteLine("Saldo atual conta poupança: " + lstClientes[id].depPoupanca.ToString());
                Console.WriteLine("Dinheiro à aplicar: " + lstClientes[id].dinheiro.ToString());

                Console.WriteLine("");
                Console.Write("Digite o valor desejado: ");
                valor = Console.ReadLine();
                ///////////////////////////////////////////////////////////////////////////////////////////////////

                //Verifica se o valor é <= 100 E verifica valor negativo e se o dinheiro que o cliente possui é >= valor digitado
                if (Convert.ToDouble(valor) <= 100 && valor.Substring(0, 1) != "-" && lstClientes[id].dinheiro >= Convert.ToDouble(valor))
                {
                    //REALIZA DEPÓSITO
                    lstClientes[id].depPoupanca += Convert.ToDouble(valor);
                    lstClientes[id].dinheiro -= Convert.ToDouble(valor);

                    //Mostra valor adicionado
                    Console.Clear();
                    Console.WriteLine("O valor de " + valor + " adicionado na conta poupança!");
                    Console.WriteLine("");
                }
                else
                {
                    //Mostra Erro
                    Console.Clear();
                    Console.WriteLine("O valor não pode ser negativo e maior que 100!");
                    Console.WriteLine("");
                }

            }
            //Se a opção foi SAQUE
            else if(opcao == 3)
            {
                //Declaração de variáveis
                int opcao2 = 0;

                //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
                Console.Clear();
                Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");
                Console.WriteLine("---ADMIN" + "/Saque");

                Console.WriteLine("");

                //Se o cliente não possui conta corrente informar na interface
                if (cCorrente)
                {
                    Console.WriteLine("1 - Cliente não possui conta corrente");
                }
                else
                {
                    Console.WriteLine("1 - Corrente");
                }

                //Se o cliente não possui conta poupança informar na interface
                if (cPoupanca)
                {
                    Console.WriteLine("2 - Cliente não possui conta poupança");
                }
                else
                {
                    Console.WriteLine("2 - Poupança");
                }
                
                Console.WriteLine("3 - Voltar");

                //Selecione a opção
                Console.WriteLine("");
                Console.Write("Selecione a opção: ");
                opcao2 = Convert.ToInt32(Console.ReadLine());
                ///////////////////////////////////////////////////////////////////////////////////////////////////

                //Se a opção selecionada for conta corrente
                if (opcao2 == 1 && !cCorrente)
                {
                    //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
                    Console.Clear();
                    Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");
                    Console.WriteLine("---ADMIN" + "/Saque");

                    Console.WriteLine("");
                    Console.WriteLine("Saldo atual: " + lstClientes[id].depCorrente.ToString());
                    Console.Write("Digite o valor desejado: ");
                    valor = Console.ReadLine();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////

                    //Se o valor contido na conta corrente for < que o valor digitado E o valor não for negativo
                    if (lstClientes[id].depCorrente < Convert.ToDouble(valor) && valor.Substring(0, 1) != "-")
                    {
                        //Mostra erro
                        Console.Clear();

                        Console.WriteLine("Saque maior do que o valor contido na conta corrente!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        //Realiza SAQUE
                        lstClientes[id].depCorrente -= Convert.ToDouble(valor);

                        Console.Clear();

                        Console.WriteLine("Saque de " + valor + " realizado em " + DateTime.Today.ToString());
                        Console.WriteLine("");
                    }

                }
                //Se a opção selecionada for conta poupança
                else if (opcao2 == 2 && !cPoupanca)
                {
                    //INTERFACE////////////////////////////////////////////////////////////////////////////////////////
                    Console.Clear();
                    Console.WriteLine("***********ADMINISTRAÇÃO DA CONTA***********");
                    Console.WriteLine("---ADMIN" + "/Saque");

                    Console.WriteLine("");
                    Console.WriteLine("Saldo atual: " + lstClientes[id].depPoupanca.ToString());
                    Console.Write("Digite o valor desejado: ");
                    valor = Console.ReadLine();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////

                    //Se o valor contido na conta corrente for < que o valor digitado E o valor não for negativo
                    if (lstClientes[id].depPoupanca < Convert.ToDouble(valor) && valor.Substring(0, 1) != "-")
                    {
                        //Mostra erro
                        Console.Clear();

                        Console.WriteLine("Saque maior do que o valor contido na conta poupança!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        //Realiza SAQUE
                        lstClientes[id].depPoupanca -= Convert.ToDouble(valor);

                        Console.Clear();

                        Console.WriteLine("Saque de " + valor + " realizado em " + DateTime.Today.ToString());
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.Clear();
                }

            }
            else
            {
                Console.Clear();
            }
            
        }
        #endregion

        #endregion



    }
}
