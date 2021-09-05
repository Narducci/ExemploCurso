Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json
Imports System.Net

Public Class Utils
    ''' <summary>
    ''' Rotina padrão de mensagem de erro.
    ''' </summary>
    ''' <param name="mensagem">Mensagem de erro.</param>
    ''' <param name="ex">Erro.</param>
    Public Shared Sub TrataErro(ByVal mensagem As String, ByVal ex As Exception)
        'Para ter acesso a função MessageBox nesta classe
        'é necessário incluir a referencia System.Windows.Forms.
        '==> Vá até o Solution Explorer, selecione "References" sob o Projeto MySQLDB:
        '==> Clique com o botão direito do mouse e selecione "Add Reference..."
        '==> Será exibida a janela "Reference Manager - MySQLDB"
        '==> No lado esquerdo da janela selecione "Assemblies";
        '==> Na caixa de procura (lado direito) digite: "system.windows"
        '==> Localise a linha system.windows.forms e marque a caixa de seleção.
        '==> Clique em Ok para finalisar e verifique que a referencia foi adicionada.
        '==> É necessário também incluir a instrução: Imports System.Windows.Forms na primeira linha

        MessageBox.Show(mensagem & vbNewLine & "Erro:" & vbNewLine &
                        ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub
    ''' <summary>
    ''' Transforma imagem para base 64.
    ''' </summary>
    ''' <param name="caminho">Caminho da imagem a ser transformada.</param>
    ''' <returns></returns>
    Public Shared Function ArquivoParaBase64(ByVal caminho As String) As String
        Try
            'LER O ARQUIVO PARA BYTES ==> linha removida... 'Dim arquivoBytes As Byte() = Convert.FromBase64String(caminho)
            Dim arquivoBytes As Byte() = File.ReadAllBytes(caminho)

            'TRANSFORMA EM BASE64
            Dim arquivoBase64 As String = Convert.ToBase64String(arquivoBytes)

            Return arquivoBase64

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Converte base 64 para imagem.
    ''' </summary>
    ''' <param name="base64">Base 64 a ser convertida.</param>
    ''' <returns></returns>
    Public Shared Function AbrirArquivoBase64(ByVal base64 As String) As Image
        Try
            'TRANSFORMA O TEXTO BASE64 EM BYTES
            Dim arquivoByte() As Byte = Convert.FromBase64String(base64)

            'TRANSFORMA OS BYTES EM STREAM E DEPOIS EM IMAGEM
            Dim ms As New MemoryStream(arquivoByte)
            Dim imagem As Image = Image.FromStream(ms)

            Return imagem

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' Busca um CEP.
    ''' </summary>
    ''' <param name="cep"></param>
    Public Shared Function PesquisaCEP(ByVal cep As String) As BuscaCEP
        Dim strEnd As String = String.Format("https://viacep.com.br/ws/{0}/json/", cep)
        Dim result As BuscaCEP

        Try
            Dim wc As New WebClient
            wc.Encoding = System.Text.Encoding.UTF8
            Dim strJson As String = wc.DownloadString(strEnd)

            result = JsonConvert.DeserializeObject(Of BuscaCEP)(strJson)

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
