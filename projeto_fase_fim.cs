using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass
{
    private static NAluno naluno = new NAluno();
    private static NMatricula nmatricula = new NMatricula();
    private static NCurso ncurso = new NCurso();
    private static NVenda nvenda = new NVenda();

    private static Aluno alunoLogin = null;
    private static Venda alunoVenda = null;

    public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int op = 0;
    int perfil = 0;
    Console.WriteLine ("----- Aplicativo Escolar ------");
    do {
            try
            {
              if (perfil == 0) {
                op = 0;
                perfil = MenuUsuario();
              }
        if (perfil == 1) {
                op = MenuUniversidade();
                switch (op)
                {
                    case 01: AlunoListar(); break;
                    case 02: AlunoInserir(); break;
                    case 03: AlunoAtualizar(); break;
                    case 04: AlunoExcluir(); break;
                    case 05: MatriculaListar(); break;
                    case 06: MatriculaInserir(); break;
                    case 07: MatriculaAtualizar(); break;
                    case 08: MatriculaExcluir(); break;
                    case 09: CursoListar(); break;
                    case 10: CursoInserir(); break;
                    case 11: CursoAtualizar(); break;
                    case 12: CursoExcluir(); break;
                    case 99: perfil = 0; break;
                }
            }

        if (perfil == 2 && alunoLogin == null) {
          op = MenuAlunoLogin();
          switch(op) {
            case 1  : AlunoLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && alunoLogin != null) {
          op = MenuAlunoLogout();
          switch(op) {
            case 1  : AlunoVendaListar(); break;
            case 2  : AlunoMatriculaListar(); break;
            case 3  : AlunoMatriculaInserir(); break;
            case 4  : AlunoCarrinhoVisualizar(); break;
            case 5  : AlunoCarrinhoLimpar(); break;
            case 6  : AlunoCarrinhoComprar(); break;
            case 99 : AlunoLogout(); break;
          }
        }
      }

            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                op = 100;
            }
        } while (op != 0);
        Console.WriteLine("Bye.....");
    }

    public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Universidade");
    Console.WriteLine("2 - Entrar como Aluno");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

    public static int MenuUniversidade()
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("01 - Aluno - Listar");
        Console.WriteLine("02 - Aluno - Inserir");
        Console.WriteLine("03 - Aluno - Atualizar");
        Console.WriteLine("04 - Aluno - Excluir");
        Console.WriteLine("05 - Matricula - Listar");
        Console.WriteLine("06 - Matricula - Inserir");
        Console.WriteLine("07 - Matricula - Atualizar");
        Console.WriteLine("08 - Matricula - Excluir");
        Console.WriteLine("09 - Curso - Listar");
        Console.WriteLine("10 - Curso - Inserir");
        Console.WriteLine("11 - Curso - Atualizar");
        Console.WriteLine("12 - Curso - Excluir");
        Console.WriteLine("13 - Venda   - Listar");
        Console.WriteLine("99 - Voltar");
        Console.WriteLine("0 - Fim");
        Console.Write("Informe uma op????o: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }

    public static int MenuAlunoLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

  public static int MenuAlunoLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + alunoLogin.Nome);
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Listar meus cursos");
    Console.WriteLine("02 - Listar matr??culas");
    Console.WriteLine("03 - Inserir um curso no carrinho");
    Console.WriteLine("04 - Visualizar o carrinho");
    Console.WriteLine("05 - Limpar o carrinho");
    Console.WriteLine("06 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
  }

    public static void AlunoListar()
    {
        Console.WriteLine("----- Lista de Alunos -----");
        Aluno[] cs = naluno.Listar();
        if (cs.Length == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado");
            return;
        }
        foreach (Aluno c in cs) Console.WriteLine(c);
        Console.WriteLine();
    }

    public static void AlunoInserir()
    {
        Console.WriteLine("----- Inser????o de Alunos -----");
        Console.Write("Informe um c??digo para aluno: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descri????o para o aluno: ");
        string descricao = Console.ReadLine();
        Console.Write("Informe o nome: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o endere??o: ");
        string endereco = Console.ReadLine();
        Console.Write("Informe o telefone: ");
        int telefone = int.Parse(Console.ReadLine());
        // Instanciar a classe de aluno
        Aluno c = new Aluno(id, descricao, nome, endereco, telefone);
        // Inser????o de aluno
        naluno.Inserir(c);
    }

    public static void AlunoAtualizar()
    {
        Console.WriteLine("----- Atualiza????o de Alunos -----");
      AlunoListar();
        Console.Write("Informe um c??digo de aluno para alterar: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descri????o de aluno: ");
        string descricao = Console.ReadLine();
        // Instanciar a classe de Aluno
        Aluno c = new Aluno(id, descricao);
        // Inser????o de Aluno
        naluno.Atualizar(c);

    }

    public static void AlunoExcluir()
    {
        Console.WriteLine("----- Exclus??o de Alunos -----");
      AlunoListar();
        Console.Write("Informe um c??digo de aluno para excluir: ");
        int id = int.Parse(Console.ReadLine());
        // Procurar o aluno com esse id
        Aluno c = naluno.Listar(id);
        // Exclui o aluno do cadastrado
        naluno.Excluir(c);
    }

     public static void MatriculaListar()
    {
        Console.WriteLine("----- Lista de Matriculas -----");
        Matricula[] ps = nmatricula.Listar();
        if (ps.Length == 0)
        {
            Console.WriteLine("Nenhuma matricula cadastrada");
            return;
        }
        foreach (Matricula p in ps) Console.WriteLine(p);
        Console.WriteLine();
    }

    public static void MatriculaInserir()
    {
        Console.WriteLine("----- Inser????o de matriculas -----");
        Console.Write("Informe um c??digo para a matricula: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descri????o: ");
        string descricao = Console.ReadLine();

        AlunoListar();
        Console.Write("Informe o c??digo do aluno com a matricula: ");
        int idaluno = int.Parse(Console.ReadLine());
        // Seleciona a categoria a partir do id
        Aluno c = naluno.Listar(idaluno);
        // Instanciar a classe de Produto
        Matricula p = new Matricula(id, descricao, c);
        // Inser????o da produto
        nmatricula.Inserir(p);
    }

    public static void MatriculaAtualizar()
    {
       Console.WriteLine("----- Atualiza????o de matriculas -----");
       MatriculaListar();
        Console.Write("Informe um c??digo para a matricula: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descri????o: ");
        string descricao = Console.ReadLine();

        AlunoListar();
        Console.Write("Informe o c??digo do aluno para a matricula: ");
        int idaluno = int.Parse(Console.ReadLine());
        // Seleciona o aluno a partir do id
        Aluno c = naluno.Listar(idaluno);
        // Instanciar a classe de Matricula
        Matricula p = new Matricula(id, descricao, c);
        // Atualiza????o de matricula
        nmatricula.Atualizar(p);

    }

    public static void MatriculaExcluir()
    {
      Console.WriteLine("----- Exclus??o de Matriculas -----");
      MatriculaListar();
        Console.Write("Informe um c??digo de matricula para excluir: ");
        int id = int.Parse(Console.ReadLine());
        // Procurar a matricula com esse id
        Matricula p = nmatricula.Listar(id);
        // Exclui a matricula do cadastrado
        nmatricula.Excluir(p);

    }

     
    public static void CursoListar() {
    Console.WriteLine("----- Lista de Cursos -----");
    // Lista os cursos
    List<Curso> cs = ncurso.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum curso cadastrado");
      return;
    }
    foreach(Curso c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void CursoInserir() {
    Console.WriteLine("----- Inser????o de Cursos -----");
        Console.Write("Informe um c??digo para curso: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descri????o para o curso: ");
        string descricao = Console.ReadLine();
        Console.Write("Informe a dura????o do curso: ");
        string duracao = Console.ReadLine();
        Console.Write("Informe o turno: ");
        string turno = Console.ReadLine();
        Console.Write("Informe o valor da mensalidade: ");
        double valormensalidade = double.Parse(Console.ReadLine());
        Console.Write("Informe o valor da matricula: ");
        double valormatricula = double.Parse(Console.ReadLine());
        // Instanciar a classe de Curso
        Curso c = new Curso { Id = id, Descricao = descricao, Duracao = duracao, Turno = turno, ValorMensalidade = valormensalidade, ValorMatricula = valormatricula };
        // Inser????o de Curso
        ncurso.Inserir(c);
  }

  public static void CursoAtualizar() {
    Console.WriteLine("----- Atualiza????o de Cursos -----");
    AlunoListar();
    Console.Write("Informe o c??digo do curso a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o para o curso: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a dura????o do curso: ");
    string duracao = Console.ReadLine();
    Console.Write("Informe o turno: ");
    string turno = Console.ReadLine();
    Console.Write("Informe o valor da mensalidade: ");
    double valormensalidade = double.Parse(Console.ReadLine());
    Console.Write("Informe o valor da matricula: ");
    double valormatricula = double.Parse(Console.ReadLine());
    // Instanciar a classe de Curso
    Curso c = new Curso { Id = id, Descricao = descricao, Duracao = duracao, Turno = turno, ValorMensalidade = valormensalidade, ValorMatricula = valormatricula };
    // Inser????o de Curso
    ncurso.Inserir(c);
  }

  public static void CursoExcluir() {
    Console.WriteLine("----- Exclus??o de Cursos -----");
    AlunoListar();
    Console.Write("Informe o c??digo do curso a ser exclu??do: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o curso com esse id
    Curso c = ncurso.Listar(id);
    // Exclui o curso do cadastro
    ncurso.Excluir(c);
  }

  public static void VendaListar() { 
    Console.WriteLine("----- Lista de Vendas -----");
    // Listar as vendas cadastradas
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma venda cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();
  }

  public static void AlunoLogin() { 
    Console.WriteLine("----- Login do Aluno -----");
    AlunoListar();
    Console.Write("Informe o c??digo do aluno para logar: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o aluno com esse id
    alunoLogin = naluno.Listar(id);
    // Abre o carrinho de compra do aluno
    alunoVenda = nvenda.ListarCarrinho(alunoLogin);
  }
  public static void AlunoLogout() { 
    Console.WriteLine("----- Logout do Aluno -----");
    if (alunoVenda != null) nvenda.Inserir(alunoVenda, true);
    // Faz o logout do aluno
    alunoLogin = null;
    alunoVenda = null;
  }
  public static void AlunoVendaListar() { 
    Console.WriteLine("----- Minhas Compras -----");
    // Listar as vendas do aluno
    List<Venda> vs = nvenda.Listar(alunoLogin);
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma compra cadastrada");
      return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();
  }

  public static void AlunoMatriculaListar() { 
    // Lista as matriculas cadastradas no sistema
    MatriculaListar();
  }
  public static void AlunoMatriculaInserir() { 
     // Lista as matriculas cadastradas no sistema
    MatriculaListar();
    Console.Write("Informe o c??digo da matricula a ser comprada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    // Procurar a matricula pelo id
    Matricula p = nmatricula.Listar(id);
    // Verifica se a matricula foi localizado
    if (p != null) {
      // Verifica se j?? existe um carrinho
      if (alunoVenda == null)
        alunoVenda = new Venda(DateTime.Now, alunoLogin);
      // Insere a matricula no carrinho
      nvenda.ItemInserir(alunoVenda, qtd, p);  
    }
  }
  public static void AlunoCarrinhoVisualizar() { 
     // Verificar se existe um carrinho
    if (alunoVenda == null) {
      Console.WriteLine("Nenhuma matricula no carrinho");
      return;
    }
    // Lista as matr??culas no carrinho
    List<VendaItem> itens = nvenda.ItemListar(alunoVenda);
    foreach(VendaItem item in itens) Console.WriteLine(item);
    Console.WriteLine();
  }
  public static void AlunoCarrinhoLimpar() { 
    // Verificar se existe um carrinho
    if (alunoVenda != null)
      nvenda.ItemExcluir(alunoVenda);
  }
  public static void AlunoCarrinhoComprar() { 
    // Verificar se existe um carrinho
    if (alunoVenda == null) {
      Console.WriteLine("Nenhuma matr??cula no carrinho");
      return;
    }
    // Salva a compra do aluno
    nvenda.Inserir(alunoVenda, false);
    // Inicia um novo carrinho
    alunoVenda = null;
  }
}

class Curso : IComparable<Curso> {
  // Propriedade do Curso
  public int Id { get; set; }
  public string Descricao { get; set; }
  public string Duracao { get; set; }
  public string Turno { get; set; }
  public double ValorMensalidade { get; set; }
  public double ValorMatricula { get; set; }
  public int CompareTo(Curso obj) {
    return this.Descricao.CompareTo(obj.Descricao);
  }
  public override string ToString() {
    return Id + " - " + Descricao + " - " + "Dura????o de: " + Duracao + " - " + "Turno: " + Turno + " - " + "Valor da Mensalidade: " + ValorMensalidade + " - " + "Valor da Matr??cula: " + ValorMatricula;
  }
}


//Classe Aluno
class Aluno
{
    private int id;
    private string descricao;
    private string nome;
    private string endereco;
    private int telefone;
    private Matricula[] matriculas = new Matricula[10];
    private int np;
    public Aluno(int id, string descricao, string nome, string endereco, int telefone)
    {
        this.id = id;
        this.descricao = descricao;
        this.nome = nome;
        this.endereco = endereco;
        this.telefone = telefone;
    }

    public Aluno(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }
    public void SetNome(string nome)
    {
        this.nome = nome;
    }
    public void SetEndereco(string endereco)
    {
        this.endereco = endereco;
    }
    public void SetTelefone(int telefone)
    {
        this.telefone = telefone;
    }
    public int GetId()
    {
        return id;
    }
    public string GetDescricao()
    {
        return descricao;
    }
    public string GetNome()
    {
        return nome;
    }
    public string GetEndereco()
    {
        return endereco;
    }
    public int GetTelefone()
    {
        return telefone;
    }
    public Matricula[] MatriculaListar()
    {
        Matricula[] c = new Matricula[np];
        Array.Copy(matriculas, c, np);
        return c;
    }
    public void MatriculaInserir(Matricula p)
    {
        if (np == matriculas.Length)
        {
            Array.Resize(ref matriculas, 2 * matriculas.Length);
        }
        matriculas[np] = p;
        np++;
    }
    private int MatriculaIndice(Matricula p){
      // Recupera o indice de uma matricula no vetor
      for (int i = 0; i < np; i++)
        if (matriculas[i] == p) return i;
      return -1;
    }
    public void MatriculaExcluir(Matricula p){
      int n = MatriculaIndice(p);
      if (n == -1) return;
      for (int i = n; i < np - 1; i++)
        matriculas[i] = matriculas[i + 1];
      np--;
    }
    public override string ToString()
    {
        return id + " - " + nome + " - N?? matriculas: " + np;
    }
}

//Classe de Matricula
class Matricula
{
    private int id;
    private string descricao;
    private Aluno aluno;
    public Matricula(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }
    public Matricula(int id, string descricao, Aluno aluno) : this(id, descricao)
    {
        this.aluno = aluno;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }
    public void SetAluno(Aluno aluno)
    {
        this.aluno = aluno;
    }
    public int GetId()
    {
        return id;
    }
    public string GetDescricao()
    {
        return descricao;
    }

    public Aluno GetAluno()
    {
        return aluno;
    }
    public override string ToString()
    {
        if (aluno == null)
            return id + " - " + descricao;
        else
            return id + " - " + descricao + " - " + aluno.GetDescricao();
    }
}

class Venda {
  // Atributos da Venda
  private int id;
  private DateTime data;
  private bool carrinho;
  // Associa????o entre venda e aluno
  private Aluno aluno;
  // Associa????o entre venda e itens de venda
  private List<VendaItem> itens = new List<VendaItem>();

  public Venda(DateTime data, Aluno aluno) {
    this.data = data;
    this.carrinho = true;
    this.aluno = aluno;
  }
  
  public void SetId(int id) {
    this.id = id;
  }
  public void SetData(DateTime data) {
    this.data = data;
  }
  public void SetCarrinho(bool carrinho) {
    this.carrinho = carrinho;
  }
  public void SetAluno(Aluno aluno) {
    this.aluno = aluno;
  }
  public int GetId() {
    return id;
  }
  public DateTime GetData() {
    return data;
  }
  public bool GetCarrinho() {
    return carrinho;
  }
  public Aluno GetAluno() {
    return aluno;
  }
  public override string ToString() {
    if (carrinho) 
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Aluno: " + aluno.Nome + " - carrinho";
    else
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Aluno: " + aluno.Nome;
  }

  private VendaItem ItemListar(Matricula p) {
    // Verificar se a matr??cula p j?? est?? na lista de itens
    foreach(VendaItem vi in itens) 
      if (vi.GetMatricula() == p) return vi;
    return null;  
  }

  public List<VendaItem> ItemListar() {
    // Retornar a lista de itens
    return itens;
  }

  public void ItemInserir(int qtd, Matricula p) {
    // Verificar se a matricula p j?? est?? na lista de itens
    VendaItem item = ItemListar(p);
    if (item == null) {
      item = new VendaItem(qtd, p);
      itens.Add(item);
    }
    else
      item.SetQtd(item.GetQtd() + qtd);
  }

  public void ItemExcluir() {
    // Remove todos os itens da lista 
    itens.Clear();
  }
}

class VendaItem {
  // Atributos do item de VendaItem
  private int qtd;
  private double preco;
  // Associa????o entre VendaItem e Matricula
  private Matricula matricula;
  public VendaItem(int qtd, Matricula matricula) {
    this.qtd = qtd;
    this.preco = matricula.GetPreco();
    this.matricula = matricula;
  }
  public void SetQtd(int qtd) {
    this.qtd = qtd;
  }
  public void SetPreco(double preco) {
    this.preco = preco;
  }
  public void SetMatricula(Matricula matricula) {
    this.matricula = matricula;
  }
  public int GetQtd() {
    return qtd;
  }
  public double GetPreco() {
    return preco;
  }
  public Matricula GetMatricula() {
    return matricula;
  }
  public override string ToString() {
    return matricula.GetDescricao() + " - Qtd:" + qtd + " - Pre??o: " + preco.ToString("c2");
  }
}

class Arquivo<T> {

  public T Abrir(string arquivo) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader f = new StreamReader(arquivo, Encoding.Default);
    T obj = (T) xml.Deserialize(f);
    f.Close();
    return obj;
  }

  public void Salvar(string arquivo, T obj) {
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
    xml.Serialize(f, obj);
    f.Close();
  }

}

class NVenda {
  private List<Venda> vendas = new List<Venda>();

  public List<Venda> Listar() {
    // Retorna uma lista com as vendas cadastradas
    return vendas;
  }

  public List<Venda> Listar(Aluno c) {
    // Retorna uma lista com as vendas cadastradas do aluno c
    List<Venda> vs = new List<Venda>();
    foreach(Venda v in vendas)
      if (v.GetAluno() == c) vs.Add(v);
    return vs;
  }

  public Venda ListarCarrinho(Aluno c) {
    // Retorna uma lista com as vendas cadastradas do cliente c
    foreach(Venda v in vendas)
      if (v.GetAluno() == c && v.GetCarrinho()) return v;
    return null;
  }

  public void Inserir(Venda v, bool carrinho) {
    // Gera o id da vendas
    int max = 0;
    foreach (Venda obj in vendas)
      if (obj.GetId() > max) max = obj.GetId();
    v.SetId(max + 1);
    // Inserir a nova na lista de vendas
    vendas.Add(v);
    // Define o atributo carrinho
    v.SetCarrinho(carrinho);
  }

  public List<VendaItem> ItemListar(Venda v) {
    // Retorna os itens da vendas
    return v.ItemListar();
  }

  public void ItemInserir(Venda v, int qtd, Matricula p) {
    // Inserir um item na vendas
    v.ItemInserir(qtd, p);
  }  

  public void ItemExcluir(Venda v) {
    // Remover todos os itens da venda
    v.ItemExcluir();
  }
}

class NCurso {
  private List<Curso> cursos = new List<Curso>();

  public List<Curso> Listar() {
    // Retorna uma listas com os cursos cadastrados
    cursos.Sort();
    return cursos;
  }

  public Curso Listar(int id) {
    // Localiza na lista o curso com o id informado
    for (int i = 0; i < cursos.Count; i++)
      if (cursos[i].Id == id) return cursos[i];
    return null;  
  }

  public void Inserir(Curso c) {
    // Gera o id do curso
    int max = 0;
    foreach(Curso obj in cursos)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    // Insere o curso na lista
    cursos.Add(c);
  } 

  public void Atualizar(Curso c) {
    // Localiza na lista o curso que possui o id informado no parametro c
    Curso c_atual = Listar(c.Id);
    // Se n??o encontrar o curso com o Id, retorna sem alterar
    if (c_atual == null) return;
    // Altera os dados do curso
    c_atual.Descricao = c.Descricao;
    c_atual.Duracao = c.Duracao;
    c_atual.Turno = c.Turno;
    c_atual.ValorMensalidade = c.ValorMensalidade;
    c_atual.ValorMatricula = c.ValorMatricula;
  } 

  public void Excluir(Curso c) {
    // Remove o curso da lista
    if (c != null) cursos.Remove(c);
  } 
}

class NAluno
{
    private Aluno[] alunos = new Aluno[10];
    private int nc;

    public Aluno[] Listar()
    {
        Aluno[] c = new Aluno[nc];
        Array.Copy(alunos, c, nc);
        return c;
    }

    public Aluno Listar(int id)
    {
        for (int i = 0; i < nc; i++)
            if (alunos[i].GetId() == id) return alunos[i];
        return null;
    }

    public void Inserir(Aluno c)
    {
        if (nc == alunos.Length)
        {
            Array.Resize(ref alunos, 2 * alunos.Length);
        }
        alunos[nc] = c;
        nc++;
    }

    public void Atualizar(Aluno c)
    {
        //Localizar no vetor o aluno que possui o id informado no parametro aluno
        Aluno c_atual = Listar(c.GetId());
        if (c_atual == null) return;
        // Aterar os dados do aluno
        c_atual.SetDescricao(c.GetDescricao());
    }

    private int Indice(Aluno c)
    {
        for (int i = 0; i < nc; i++)
            if (alunos[i] == c) return i;
        return -1;
    }

    public void Excluir(Aluno c)
    {
      // Verifica se o aluno est?? cadastrado
      int n = Indice(c);
      if (n == -1) return;
      for (int i = n; i < nc - 1; i++)
          alunos[i] = alunos[i + 1];
      nc--;
      // Recuperar a lista de matriculas do aluno
      Matricula[] ps = c.MatriculaListar();
      foreach (Matricula p in ps) p.SetAluno(null);

    }

}

class NMatricula
{
    private Matricula[] matriculas = new Matricula[10];
    private int np;

    public Matricula[] Listar()
    {
        Matricula[] p = new Matricula[np];
        Array.Copy(matriculas, p, np);
        return p;
    }

    public Matricula Listar(int id)
    {
        for (int i = 0; i < np; i++)
            if (matriculas[i].GetId() == id) return matriculas[i];
        return null;
    }

    public void Inserir(Matricula p)
    {
        if (np == matriculas.Length)
        {
            Array.Resize(ref matriculas, 2 * matriculas.Length);
        }
        matriculas[np] = p;
        np++;
        // Recuperar a categoria da matricula que est?? sendo inserido
        Aluno c = p.GetAluno();
        // Se a matricula tem um categoria, insere ele nessa categoria
        if (c != null) c.MatriculaInserir(p);
    }

     public void Atualizar(Matricula p) {
    // Localiza no vetor a matricula que possui o id informado no parametro p
    // Se n??o encontrar a matricula com o Id, retorna sem alterar
    Matricula p_atual = Listar(p.GetId());
    if (p_atual == null) return;
    // Alterar os dados da matricula
    p_atual.SetDescricao(p.GetDescricao());
    // Exclui a matricula do atual aluno
    if (p_atual.GetAluno() != null) 
      p_atual.GetAluno().MatriculaExcluir(p_atual);
    // Atualiza a categoria da matricula
    p_atual.SetAluno(p.GetAluno());
    // Insere a nova matricula do aluno
    if (p_atual.GetAluno() != null)
      p_atual.GetAluno().MatriculaInserir(p_atual);
  }

  private int Indice(Matricula p) {
    // Retorna o ??ndice da matricula no vetor
    for(int i = 0; i < np; i++)
      if (matriculas[i] == p) return i;
    return -1;  
  }

  public void Excluir(Matricula p) {
    // Verifica se a matricula est?? cadastrado
    int n = Indice(p);
    // Se n??o encontrar a matricula, retorna sem alterar
    if (n == -1) return;
    // Desloca as matriculas no vetor para substituir o ??ndice da matricula exclu??do
    // Remove a matricula do vetor
    for (int i = n; i < np - 1; i++)
      matriculas[i] = matriculas[i + 1];
    // Decrementa o contador de matriculas
    np--;
    // Remove a matricula do aluno
    Aluno c = p.GetAluno();
    if (c != null) c.MatriculaExcluir(p);  
  }
}
