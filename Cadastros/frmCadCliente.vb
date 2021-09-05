Imports DataBase
Imports System.Drawing
Imports System.Windows.Forms
Imports DataBase.Utils

Public Class frmCadCliente

#Region "Variáveis"
    Private Enum Opcao As Integer
        Cancelar = 0
        Incluir = 1
        Editar = 2
        Consultar = 3
    End Enum
    Private intOpcao As Opcao

#End Region
#Region "Métodos"
    'Ativar/desativar controles
    Private Sub AtivaDesativa(ByVal Status As Boolean)
        rbFisico.Enabled = Status
        rbJuridico.Enabled = Status
        If Status = False Then
            txtId.Enabled = Status
            btnPesquisar.Enabled = Status
        End If
        txtBairro.Enabled = Status
        txtCep.Enabled = Status
        txtCidade.Enabled = Status
        txtComplemento.Enabled = Status
        txtCpfCnpj.Enabled = Status
        txtEmail.Enabled = Status
        txtFantasia.Enabled = Status
        txtFone1.Enabled = Status
        txtFone2.Enabled = Status
        txtInsEstadual.Enabled = Status
        txtInsMunicipal.Enabled = Status
        txtLogradouro.Enabled = Status
        txtNome.Enabled = Status
        txtNumero.Enabled = Status
        txtUf.Enabled = Status

    End Sub
#End Region
    Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
        'TIPO DE OPERAÇÃO
        intOpcao = Opcao.Editar
        '
        'CONFIGURA OS BOTÕES
        tsbIncluir.Enabled = False
        tsbEditar.Enabled = False
        tsbConsultar.Enabled = False
        tsbCancelar.Enabled = True
        '
        'ATIVANDO OS CONTROLES
        txtId.Enabled = True
        btnPesquisar.Enabled = True
        txtId.Focus()
    End Sub

    Private Sub tsbIncluir_Click(sender As Object, e As EventArgs) Handles tsbIncluir.Click
        'TIPO DE OPERAÇÃO
        intOpcao = Opcao.Incluir
        '
        'CONFIGURA OS BOTÕES
        tsbIncluir.Enabled = False
        tsbEditar.Enabled = False
        tsbConsultar.Enabled = False
        tsbCancelar.Enabled = True
        '
        'ATIVANDO OS CONTROLES
        txtId.Enabled = True
        btnPesquisar.Enabled = True
        txtId.Focus()

        'CONFIGURA OS BOTÕES
        tsbIncluir.Enabled = False
        tsbEditar.Enabled = False
        tsbConsultar.Enabled = False
        tsbCancelar.Enabled = True
        tsbGravar.Enabled = True
        '
        'ATIVANDO OS CONTROLES
        AtivaDesativa(True)
        rbJuridico.Checked = True
        txtNome.Focus()
    End Sub

    Private Sub tsbConsultar_Click(sender As Object, e As EventArgs) Handles tsbConsultar.Click
        'TIPO DE OPERAÇÃO
        intOpcao = Opcao.Consultar
        '
        'CONFIGURA OS BOTÕES
        tsbIncluir.Enabled = False
        tsbEditar.Enabled = False
        tsbConsultar.Enabled = False
        tsbCancelar.Enabled = True
        '
        'ATIVANDO OS CONTROLES
        txtId.Enabled = True
        btnPesquisar.Enabled = True
        txtId.Focus()
        '
        'CONFIGURA OS BOTÕES
        tsbIncluir.Enabled = False
        tsbEditar.Enabled = False
        tsbConsultar.Enabled = False
        tsbCancelar.Enabled = True
        '
        'ATIVANDO OS CONTROLES
        txtId.Enabled = True
        btnPesquisar.Enabled = True
        txtId.Focus()
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        'PERGUNTA PARA O USUÁRIO
        If intOpcao = Opcao.Incluir And txtNome.TextLength > 0 Then
            If MessageBox.Show("Você tem certeza que deseja cancelar?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        ElseIf intOpcao = Opcao.Editar And txtId.Enabled = False Then
            If MessageBox.Show("Você tem certeza que deseja cancelar?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If
        '
        'SET TIPO DE OPERAÇÃO
        intOpcao = Opcao.Cancelar
        '
        'LIMPA OS CONTROLES
        rbFisico.Checked = False
        rbJuridico.Checked = False
        txtBairro.Clear()
        txtCep.Clear()
        txtCidade.Clear()
        txtComplemento.Clear()
        txtCpfCnpj.Clear()
        txtEmail.Clear()
        txtFantasia.Clear()
        txtFone1.Clear()
        txtFone2.Clear()
        txtId.Clear()
        txtInsEstadual.Clear()
        txtInsMunicipal.Clear()
        txtLogradouro.Clear()
        txtNome.Clear()
        txtNumero.Clear()
        txtUf.Clear()
        dtpAlteracao.Value = Now.Date
        dtpInclusao.Value = Now.Date
        AtivaDesativa(False)
        '
        'VOLTA A CONFIGURAÇÃO DOS BOTÕES    
        tsbIncluir.Enabled = True
        tsbEditar.Enabled = True
        tsbConsultar.Enabled = True
        tsbCancelar.Enabled = False
        tsbGravar.Enabled = False

    End Sub

    Private Sub rbFisico_CheckedChanged(sender As Object, e As EventArgs) Handles rbFisico.CheckedChanged
        txtFantasia.Enabled = False
        txtFantasia.Clear()
        'txtCpfCnpj.ValidaCPF=True
        txtInsEstadual.Enabled = False
        txtInsMunicipal.Enabled = False
        lblCgcCnpj.Text = "CGC:"
    End Sub

    Private Sub rbJuridico_CheckedChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckedChanged
        txtFantasia.Enabled = True
        'txtVPFCNPJ.ValidaCNPJ = True
        txtInsEstadual.Enabled = True
        txtInsMunicipal.Enabled = True
        lblCgcCnpj.Text = "CNPJ:"
    End Sub

    Private Sub txtNome_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNome.Validating
        If txtNome.TextLength > 0 Then
            epValida.SetError(txtNome, "")
        End If
    End Sub

    Private Sub txtFone1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFone1.Validating
        If txtFone1.TextLength > 0 Then
            epValida.SetError(txtFone1, "")
        End If
    End Sub

    Private Sub txtCep_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCep.Validating
        If txtCep.TextLength > 0 Then
            epValida.SetError(txtCep, "")
        End If

    End Sub

    Private Sub txtLogradouro_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLogradouro.Validating
        If txtLogradouro.TextLength > 0 Then
            epValida.SetError(txtLogradouro, "")
        End If
    End Sub

    Private Sub txtNumero_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumero.Validating
        If txtNumero.TextLength > 0 Then
            epValida.SetError(txtNumero, "")
        End If
    End Sub

    Private Sub txtBairro_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtBairro.Validating
        If txtBairro.TextLength > 0 Then
            epValida.SetError(txtBairro, "")
        End If
    End Sub

    Private Sub txtCidade_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCidade.Validating
        If txtCidade.TextLength > 0 Then
            epValida.SetError(txtCidade, "")
        End If
    End Sub

    Private Sub txtUf_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUf.Validating
        If txtUf.TextLength > 0 Then
            epValida.SetError(txtUf, "")
        End If
    End Sub

    Private Sub tsbGravar_Click(sender As Object, e As EventArgs) Handles tsbGravar.Click
        Dim blnValida As Boolean = True
        Dim objCliente As CAD_CLIENTE

        Try
            'VALIDAÇÃO DOS CAMPOS OBRIGATÓRIOS
            If txtNome.TextLength = 0 Then
                epValida.SetError(txtNome, "Informar o campo nome.")
                blnValida = False
            End If
            If txtFantasia.TextLength = 0 And rbJuridico.Checked = True Then
                epValida.SetError(txtFantasia, "Informar campo Fantasia.")
                blnValida = False
            End If
            If txtCpfCnpj.TextLength = 0 Then 'If txtCpfCnpj.isvalido = False Then
                '    blnValida = False
            End If
            If txtFone1.TextLength = 0 Then
                epValida.SetError(txtFone1, "Informar um Telefone.")
                blnValida = False
            End If
            If txtCep.TextLength = 0 Then
                epValida.SetError(txtCep, "Informar o campo CEP.")
                blnValida = False
            End If
            If txtLogradouro.TextLength = 0 Then
                epValida.SetError(txtLogradouro, "Informar o campo Logradouro.")
                blnValida = False
            End If
            If txtBairro.TextLength = 0 Then
                epValida.SetError(txtBairro, "Informar o campo Bairro.")
                blnValida = False
            End If
            If blnValida = False Then Exit Sub
            '
            'INSTANCIA A CLASSE
            objCliente = New CAD_CLIENTE With {
                .BAIRRO_CLIENTE = txtBairro.Text,
                .CEP_CLIENTE = txtCep.Text,
                .CIDADE_CLIENTE = txtCidade.Text,
                .COMPLEMENTO_CLIENTE = txtComplemento.Text,
                .CPF_CNPJ_CLIENTE = txtCpfCnpj.Text,
                .EMAIL_CLIENTE = txtEmail.Text,
                .ENDERECO_CLIENTE = txtLogradouro.Text,
                .FONE_CLIENTE_1 = txtFone1.Text,
                .FONE_CLIENTE_2 = txtFone2.Text,
                .FANTASIA_CLIENTE = txtFantasia.Text,
                .INSC_ESTADUAL_CLIENTE = txtInsEstadual.Text,
                .INSC_MUNICIPAL_CLIENTE = txtInsMunicipal.Text,
                .NOME_CLIENTE = txtNome.Text,
                .NUMERO_CLIENTE = txtNumero.Text,
                .TIPO_CLIENTE = IIf(rbFisico.Checked, "F", "J"),
                .UF = txtUf.Text}
            If txtId.TextLength > 0 Then
                objCliente.ID_CLIENTE = Convert.ToInt32(txtId.Text)
            End If
            '
            'SELECIONA O TIPO DE OPERAÇÃO
            Select Case intOpcao
                Case Opcao.Incluir
                    If objCliente.NovoCliente Then
                        'SETA TIPO OPERAÇÃO
                        intOpcao = Opcao.Cancelar
                        '
                        'CHAMA SUBROTINA PARA LIMPAR
                        tsbCancelar_Click(Nothing, Nothing)
                        '
                        'FAZ PERGUNTA PARA ADICIONAR OUTRO
                        If MessageBox.Show("Cliente adicionado com sucesso!" & vbNewLine &
                                           "Deseja adicionar outro?", "Aviso",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            'CHAMA ROTINA PARA INCLUIR OUTRO
                            tsbIncluir_Click(Nothing, Nothing)
                        End If
                    Else
                        MessageBox.Show("Problema ao tentar gravar cliente.", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                    End If
                Case Opcao.Editar
                    If objCliente.AtualizaCliente Then
                        'SETA TIPO OPERAÇÃO
                        intOpcao = Opcao.Cancelar
                        '
                        'CHAMA SUBROTINA PARA LIMPAR
                        tsbCancelar_Click(Nothing, Nothing)
                        '
                        'FAZ PERGUNTA PARA ADICIONAR OUTRO
                        If MessageBox.Show("Cliente alterado com sucesso!" & vbNewLine &
                                           "Deseja alterar outro?", "Aviso",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            'CHAMA ROTINA PARA INCLUIR OUTRO
                            tsbEditar_Click(Nothing, Nothing)
                        End If
                        Else
                            MessageBox.Show("Problema ao tentar gravar cliente.", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                    End If

            End Select

            If txtCidade.TextLength = 0 Then
                epValida.SetError(txtCidade, "Informar o campo Cidade.")
                blnValida = False
            End If
            If txtUf.TextLength = 0 Then
                epValida.SetError(txtUf, "Informar o campo UF.")
                blnValida = False
            End If
        Catch ex As Exception
            TrataErro("Problema ao tentar gravar cliente.", ex)
        End Try
    End Sub
    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown
        If txtId.TextLength > 0 And e.KeyCode = Keys.Enter Then
            Dim objCliente As New CAD_CLIENTE

            Try
                objCliente.ID_CLIENTE = Convert.ToInt32(txtId.Text)
                'PREENCHE OS DADOS
                If objCliente.BuscaCliente Then
                    txtBairro.Text = objCliente.BAIRRO_CLIENTE
                    txtCep.Text = objCliente.CEP_CLIENTE
                    txtCidade.Text = objCliente.CIDADE_CLIENTE
                    txtComplemento.Text = objCliente.COMPLEMENTO_CLIENTE
                    txtCpfCnpj.Text = objCliente.CPF_CNPJ_CLIENTE
                    txtEmail.Text = objCliente.EMAIL_CLIENTE
                    txtFantasia.Text = objCliente.FANTASIA_CLIENTE
                    txtFone1.Text = objCliente.FONE_CLIENTE_1
                    txtFone2.Text = objCliente.FONE_CLIENTE_2
                    txtInsEstadual.Text = objCliente.INSC_ESTADUAL_CLIENTE
                    txtInsMunicipal.Text = objCliente.INSC_MUNICIPAL_CLIENTE
                    txtLogradouro.Text = objCliente.ENDERECO_CLIENTE
                    txtNome.Text = objCliente.NOME_CLIENTE
                    txtNumero.Text = objCliente.NUMERO_CLIENTE
                    txtUf.Text = objCliente.UF
                    dtpInclusao.Value = objCliente.DATA_INCLUSAO_CLIENTE.Date
                    If objCliente.DATA_ALTERACAO_CLIENTE <> CDate("01/01/0001") Then
                        dtpAlteracao.Value = objCliente.DATA_ALTERACAO_CLIENTE.Date
                    End If
                    '
                    'VERIFICA O TIPO DE OPERAÇÃO
                    If intOpcao = Opcao.Editar Then
                        txtId.Enabled = False
                        btnPesquisar.Enabled = False
                        AtivaDesativa(True)
                        tsbGravar.Enabled = True
                        txtNome.Focus()
                    End If
                    '
                    'ATUALIZA O TIPO APÓS VERIFICAR A OPERAÇÃO PARA EXIBIR/ENIBIR CAMPOS CORRESPONDENTES
                    If objCliente.TIPO_CLIENTE = CAD_CLIENTE.Fisico Then
                        rbFisico.Checked = True
                    Else
                        rbJuridico.Checked = True
                    End If
                Else
                    MessageBox.Show("Id não cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                TrataErro("Problema ao tentar localizar cliente.", ex)
            End Try
        End If

    End Sub

    Private Sub txtCep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCep.KeyDown


        If txtCep.TextLength > 0 And e.KeyCode = Keys.Enter Then
            Try
                Dim cep As BuscaCEP = PesquisaCEP(txtCep.Text.Replace("-", ""))
                txtLogradouro.Text = cep.logradouro
                txtBairro.Text = cep.bairro
                txtCidade.Text = cep.localidade
                txtUf.Text = cep.uf
                txtNumero.Focus()
            Catch ex As Exception
                TrataErro("Problema ao tentar consultar cep, verifique sua conexão com a internet.", ex)
            End Try


        End If
    End Sub

    Private Sub frmCadCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'PROGRAMA OS ATALHOS DO TECLADO
        If tsbIncluir.Enabled = True And e.KeyCode = Keys.F2 Then
            tsbIncluir_Click(Nothing, Nothing)
        ElseIf tsbEditar.Enabled = True And e.KeyCode = Keys.F3 Then
            tsbEditar_Click(Nothing, Nothing)
        ElseIf tsbConsultar.Enabled = True And e.KeyCode = Keys.F4 Then
            tsbConsultar_Click(Nothing, Nothing)
        ElseIf tsbGravar.Enabled = True And e.KeyCode = Keys.F5 Then
            tsbGravar_Click(Nothing, Nothing)
        ElseIf tsbCancelar.Enabled = True And e.KeyCode = Keys.Escape Then
            tsbCancelar_Click(Nothing, Nothing)
        End If
    End Sub
End Class