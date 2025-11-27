# Além do Mapa - Sistema de Gestão de Agência de Viagens

Um aplicativo de desktop em **C# / Windows Forms** que gerencia reservas de viagens com autenticação por senha **e reconhecimento facial** integrado.

---

## 📋 Visão Geral

Este projeto é um sistema completo para uma agência de viagens que permite:

- ✅ **Autenticação de funcionários** (senha ou rosto)
- ✅ **Cadastro de rostos** para reconhecimento facial
- ✅ **Gestão de clientes e funcionários** (CRUD)
- ✅ **Criação e visualização de reservas** (viagens, hotéis, passagens)
- ✅ **Histórico de acessos** (quem entrou e quando)
- ✅ **Relatórios em PDF**
- ✅ **Painel de administrador**



## 👥 Equipa & Créditos

- **Hernani Machado** - [@bengazai](https://www.instagram.com/bengazai/)
- **Nazaré Sant'Ana** - [@iamnaza1](https://www.instagram.com/iamnaza1/)
- **Júlio Peliganga** - [@juliopelinganga](https://www.instagram.com/juliopelinganga/)
- **Jolinda Cabando**
- **David Coutinho** - [@davidcoutinho80](https://www.instagram.com/davidcoutinho80/)
- **Aldo Bruno** - [@aldo.dasilva](https://www.facebook.com/aldo.dasilva.7146/)
- **Beny Reis** - [@bkapa8](https://www.instagram.com/bkapa8/)

---


## 🎮 Como Funciona (Visão Simples)

### 1️⃣ **Arranque da Aplicação**
```
App inicia → Tela Inicial (InicioForm)
```
O utilizador vê opções: Login, Cadastro, etc.

### 2️⃣ **Autenticação por Senha**
```
Username + Password → Banco de dados valida → Menu Principal
```

### 3️⃣ **Autenticação por Rosto** (O legal!)
```
a) PRIMEIRA VEZ: Cadastrar rosto
   Câmera liga → Detecta a sua cara → Guarda no banco

b) PRÓXIMAS VEZES: Login com rosto
   Câmera liga → Compara com caras guardadas → Reconhece → Login automático
```

### 4️⃣ **Dentro do Sistema**
- Criar reservas de viagens
- Ver histórico de reservas
- Gerar relatórios (PDF)
- Admin pode gerir tudo

---

## 🔍 Como Funciona o Reconhecimento Facial

### **Fase 1: Treinamento (Setup)**
```
Sistema carrega todos os rostos guardados na BD
        ↓
Converte cada rosto para preto e branco (grayscale)
        ↓
Extrai padrões especiais de cada rosto
(usando algoritmo LBPH - Local Binary Patterns Histograms)
        ↓
"Aprende" a reconhecer cada funcionário
```

### **Fase 2: Reconhecimento em Tempo Real**
```
Câmera ligada → Para cada fotograma:
        ↓
1. Detecta caras (usando Haar Cascade XML)
2. Para cada cara encontrada:
   - Extrai apenas o rosto
   - Converte para preto e branco
   - Compara com rostos conhecidos
   - Calcula semelhança (0-100)
        ↓
3. Se semelhança < 60 → "Esta é a cara do João!"
   Se semelhança > 60 → "Não reconheço..."
```

### **Analogia Fácil**
Imagina um **guarda de segurança** numa discoteca:
- Primeiro, memoriza as caras dos VIPs (treinamento)
- Depois, quando alguém chega, olha e diz:
  - "Hmm, 95% de certeza que é o João" → Entra!
  - "Não reconheço esta cara" → Pede bilhete

---

## 🛠️ Tecnologias Usadas

| Componente | Versão | Descrição |
|---|---|---|
| **.NET Framework** | 4.7.2 | Plataforma base |
| **Windows Forms** | Nativa | Interface gráfica |
| **MySQL** (XAMPP) | 9.5.0 | Banco de dados |
| **Emgu CV** | 4.4.0 | Visão computacional (rosto) |
| **iTextSharp** | 5.5.13 | Geração de PDFs |
| **BouncyCastle** | 2.6.2 | Criptografia |

---

## 📁 Estrutura do Projeto

```
ReservaDeViagens/
├── Program.cs                    # Ponto de entrada (main)
├── App.config                    # Configurações
├── ReservaDeViagens.csproj       # Arquivo do projeto
├── packages.config               # Dependências NuGet
│
├── Forms/                        # Telas da aplicação
│   ├── InicioForm.cs            # Tela inicial
│   ├── LoginForm.cs             # Login por senha
│   ├── LerRostoForm.cs          # Login por rosto (reconhecimento)
│   ├── CadastrarRostoForm.cs    # Registar novo rosto
│   ├── MenuForm.cs              # Menu principal
│   ├── ViagemForm.cs            # Criar reserva
│   ├── verReservaForm.cs        # Ver reservas
│   ├── AdminClientForm.cs       # Gerir clientes (admin)
│   ├── AdminFuncionarioForm.cs  # Gerir funcionários (admin)
│   ├── HistoricoAcessosForm.cs  # Ver logs de acesso
│   └── ... (outras forms)
│
├── Resources/
│   ├── haarcascade_frontalface_default.xml  # Detector de rostos (OpenCV)
│   └── logo/ imagens/
│
└── bin/
    ├── Debug/                   # Compilação debug
    └── Release/                 # Compilação release
```

---

## 🚀 Como Instalar e Executar

### Requisitos Prévios

- **Visual Studio** 2017/2019/2022 (com suporte .NET Framework 4.7.2)
- **XAMPP** (versão PHP 8.2+)
- **MySQL Workbench**
- **Câmera de computador** (para reconhecimento facial)

### Passo 1: Clonar/Descarregar o Projeto

Baixe agora [Aqui](https://github.com/bybenb/project_BeyondTheMap/archive/refs/heads/master.zip) ou Clonando assim:

```bash
# Se no repositório Git
git clone https://github.com/bybenb/project_BeyondTheMap.git
cd project_BeyondTheMap/sourceCode
```

### Passo 2: Criar a Base de Dados

1. Abra o **MySQL Workbench** ou similar
2. Importe o arquivo `BD Agencia de Viagens.sql`:

```sql
-- No MySQL Workbench, execute:
source "caminho/para/BD Agencia de Viagens.sql"
```

Ou, se usar linha de comando:

```bash
mysql -u root -p < "BD Agencia de Viagens.sql"
```

### Passo 3: Verificar a Connection String

No código, a ligação ao banco está definida em cada Form (procure por `data_source`):

```csharp
string data_source = "datasource=localhost;username=root;password=;database=tripagency";
```

**Ajuste se necessário:**
- `localhost` → IP ou hostname do servidor MySQL
- `root` → seu username MySQL
- `password=` → sua senha (deixe vazio se não tiver)
- `tripagency` → nome da base de dados

### Passo 4: Abrir em Visual Studio

1. Abra `ReservaDeViagens.sln` no Visual Studio
2. Clique em **Build → Build Solution** (ou Ctrl+Shift+B)
3. Aguarde a compilação
4. Pressione **F5** para executar

### Passo 5: Primeiro Login

Teste com credenciais padrão (se existirem na BD):
- Username: `admin` (ou outro definido no banco)
- Password: `123456` (ou conforme criou)

---

## 🔐 Autenticação Detalhada

### Login por Senha
```
1. Utilizador abre "Login com Senha"
2. Escreve username e password
3. Sistema verifica na tabela "funcionarios"
4. Se correto:
   - Regista entrada na tabela "log_acessos"
   - Abre Menu Principal
5. Se errado:
   - Mostra erro
   - Deixa tentar novamente
```

### Login por Rosto (Reconhecimento Facial)
```
1. Sistema carrega TODOS os rostos guardados do banco
2. "Ensina" o algoritmo LBPH a reconhecer cada rosto
3. Câmera ligada
4. Para cada frame do vídeo:
   - Detecta caras (usando Haar Cascade)
   - Compara com rostos conhecidos
   - Calcula semelhança (0-100)
5. Se semelhança < 60:
   - "Encontrei! Bem-vindo [Nome]!"
   - Regista entrada e abre Menu
6. Se semelhança > 60:
   - "Não reconheço..."
   - Continua a tentar
```

---

## 📸 Cadastro de Rosto

Antes de fazer login com rosto, o funcionário precisa registar a sua cara:

```
1. Clica em "Cadastrar Rosto"
2. Câmera ligada
3. Sistema detecta automaticamente caras (retângulo verde)
4. Utilizador posiciona o rosto bem
5. Clica "Capturar"
6. Foto do rosto guardada no banco (como imagem JPEG)
7. Próxima vez pode fazer login apenas com rosto!
```

**Dica:** Para melhor reconhecimento:
- Iluminação boa e frente para a câmera
- Sem óculos ou chapéus
- Rosto limpo (sem barba/bigode recente)

---

## 📊 Base de Dados - Tabelas Principais

| Tabela | Descrição |
|---|---|
| `funcionarios` | Dados dos funcionários (id, nome, username, password, etc.) |
| `clientes` | Dados dos clientes |
| `RostoFuncionario` | Foto do rosto de cada funcionário (blob JPEG) |
| `log_acessos` | Registro de quem entrou e quando (login/logout) |
| `viagens` | Informações de viagens disponíveis |
| `hoteis` | Hotéis parceiros |
| `passagens` | Companhias aéreas e passagens |
| `reservas` | Reservas criadas pelos clientes |

---

## ⚙️ Funcionalidades Principais

### 👤 Cliente Pode:
- ✅ Ver perfil
- ✅ Fazer nova reserva (viagem + hotel + passagem)
- ✅ Ver histórico de reservas
- ✅ Ver histórico de acessos

### 👨‍💼 Funcionário Pode:
- ✅ Tudo que cliente pode
- ✅ Ver outros clientes

### 🛡️ Admin Pode:
- ✅ Tudo que funcionário pode
- ✅ Gerir clientes (adicionar, editar, deletar)
- ✅ Gerir funcionários (adicionar, editar, deletar)
- ✅ Ver todos os logs de acesso
- ✅ Gerar relatórios (PDF)

---

## 🐛 Resolução de Problemas

### ❌ "Erro de conexão com banco de dados"
**Solução:**
- Verifique se MySQL Server está a correr
- Verifique a connection string (username, password, IP)
- Verifique se base de dados `tripagency` existe

### ❌ "Arquivo haarcascade_frontalface_default.xml não encontrado"
**Solução:**
- Verifique se o arquivo está na pasta `Resources` do projeto
- Se não estiver, copie de `sources/haarcascade_frontalface_default.xml`
- Reconstrua a solução (Build)

### ❌ "Câmera não funciona"
**Solução:**
- Verifique se Windows tem permissão para câmera (Configurações → Privacidade → Câmera)
- Feche outras aplicações que usem câmera
- Reinicie a aplicação

### ❌ "Reconhecimento facial muito lento ou impreciso"
**Solução:**
- Melhore a iluminação
- Aumente o número de rostos registados para treino mais robusto
- Ajuste o threshold (valor 60) no código `LerRostoForm.cs` se necessário

---

## 📝 Notas para Desenvolvedores

### Segurança ⚠️
- ⚠️ **IMPORTANTE:** Connection string está hardcoded no código (NÃO USAR EM PRODUÇÃO!)
- ⚠️ Mover para `App.config` ou variáveis de ambiente
- ⚠️ Implementar hash de passwords (usar bcrypt, não plain text)
- ⚠️ Adicionar HTTPS/TLS para comunicação

### Melhorias Futuras 💡
- Refatorar: Centralizar queries em camada de acesso a dados (DAL)
- Melhorar UX: Feedback visual melhor (barras de progresso, contadores)
- Performance: Cache de rostos em memória
- Teste: Adicionar testes unitários
- Mobile: Considerar versão web/mobile

### Estrutura de Código Atual
```csharp
// Padrão ATUAL (disperso):
public class LoginForm : Form {
    private void btnLogin_Click(...) {
        using (MySqlConnection conn = new MySqlConnection(data_source)) {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            // ... lógica aqui
        }
    }
}

// Padrão RECOMENDADO (refatorado):
public class UsuarioDAL {
    public bool ValidarCredenciais(string username, string password) {
        // Toda a lógica de BD centralizada aqui
    }
}

public class LoginForm : Form {
    private void btnLogin_Click(...) {
        UsuarioDAL dal = new UsuarioDAL();
        if (dal.ValidarCredenciais(username, password)) {
            // Abrir menu
        }
    }
}
```

---

## 📚 Referências Externas

- [Microsoft Docs - Windows Forms](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Emgu CV Documentation](https://www.emgu.com/)
- [MySQL Connector/NET](https://dev.mysql.com/doc/connector-net/en/)
- [iTextSharp Tutorial](https://itextpdf.com/)

---


## 📄 Licença

Este projeto foi desenvolvido para fins educacionais/académicos.

---

## 📞 Suporte

Para dúvidas ou problemas:
1. Consulte a secção "Resolução de Problemas" acima
2. Verifique os logs do MySQL
3. Contacte um membro da equipa

---

**Última atualização:** Novembro 2025  
**Versão:** 1.0
