# 🍔 **BurguerManiaAPI - Backend**

O backend do projeto **BurguerMania** foi desenvolvido utilizando o **ASP.NET Core** e tem como objetivo fornecer as APIs necessárias para gerenciar os dados de pedidos, cardápio e categorias de produtos. Este projeto segue os princípios de boas práticas, incluindo separação de responsabilidades, uso de interfaces, e configurações baseadas em `appsettings.json`.

---

## **Principais Funcionalidades**

### 1. **APIs Implementadas**
O sistema disponibiliza endpoints RESTful para as seguintes operações:
- **Categorias**:
  - Obter todas as categorias de hambúrgueres.
- **Produtos**:
  - Obter a lista de produtos de acordo com a categoria.
- **Pedidos**:
  - Criar pedidos de produtos.
  - Listar pedidos realizados.
- **Clientes**
    - Os Clientes podem fazer o cadastro e logar na conta.

### 2. **Tecnologias Utilizadas**
- **Microsoft.EntityFrameworkCore (Versão 8.0.10)**.
- **Microsoft.EntityFrameworkCore.Design (Versão 8.0.10)**.
- **Microsoft.EntityFrameworkCore.SqlServer (Versão 8.0.10)**.
- **Microsoft.EntityFrameworkCore.Tools (Versão 8.0.10)**.
- **Microsoft.VisualStudio.Web.CodeGeneration.Design (Versão 8.0.6)**.
- **Pomelo.EntityFrameworkCore.MySql (Versão 8.0.2)**.
- **Swashbuckle.AspNetCore (Versão 6.9.0)**.

---

## **Configuração do Projeto**

### **Pré-requisitos**
- **.NET 6.0 SDK** ou superior instalado.
- **SQL Server** ou outro banco de dados configurado.
- Ferramentas recomendadas:
  - Visual Studio ou Visual Studio Code.
  - Xampp.

### **Configuração do Banco de Dados**
1. Configure a string de conexão no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=BurgerManiaDb;Trusted_Connection=True;"
   }
   ```
2. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```
3. Dados do Banco no **burguermania.sql**

---

## **Como Executar**

### **1. Clonar o Repositório**
```bash
git clone https://github.com/Gabriel-Gald1n0/BurguerManiaAPI.git
cd BurguerManiaAPI/BurguerMania
```

### **2. Restaurar Pacotes**
```bash
dotnet restore
```

### **3. Aplicar as migrações no banco de dados**
Se ainda não tiver feito as migrações, execute o seguinte comando para criar a base de dados:

```bash
dotnet ef migrations add InitialCreate
```

```bash
dotnet ef database update
```

### **4. Compilar o Projeto**
```bash
dotnet build
```

### **5. Executar a Aplicação**
```bash
dotnet run
```
A aplicação estará disponível em `https://localhost:5001` (ou `http://localhost:5000` para HTTP).

---

## **Documentação da API com Swagger**

O Swagger está configurado para fornecer uma documentação interativa. Para acessá-la:
1. Inicie o servidor.
2. Acesse `https://localhost:5001/swagger` em seu navegador.
3. Teste os endpoints diretamente na interface do Swagger.

---

## **Estrutura de Pastas**

A estrutura do projeto foi organizada seguindo boas práticas:

```plaintext
BurguerMania
├── Context             # Configuração do banco de dados (DbContext)
├── Controllers         # Controladores responsáveis pelos endpoints
├── Dto                # Data Transfer Objects para validação e transporte de dados
├── Interfaces          # Interfaces para abstração dos serviços e repositórios
├── Migrations          # Arquivos de migração gerados pelo Entity Framework
├── Models              # Modelos das entidades do banco de dados
├── Services            # Serviços para lógica de negócios
├── appsettings.json    # Configurações da aplicação
├── Program.cs          # Ponto de entrada da aplicação
```

### **Testando APIs**
Use ferramentas como **Swagger** para testar os endpoints.

---

