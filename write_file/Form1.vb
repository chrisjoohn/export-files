Imports Newtonsoft.Json
Public Class Form1
    Dim name_input As String
    Dim age As String
    Dim address As String

    Dim file As System.IO.StreamWriter


    Private Sub TextBox2_keyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\CJMulingbayan\Documents\Visual Studio 2015\Projects\write_file\write_file\exported_files\" + name_input + ".txt", True)
        name_input = TextBox1.Text
        age = TextBox2.Text
        address = TextBox3.Text

        file.WriteLine("name: " + name_input)
        file.WriteLine("age: " + age)
        file.WriteLine("address: " + address)

        file.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        name_input = TextBox1.Text
        age = TextBox2.Text
        address = TextBox3.Text

        Dim xml_document As XDocument = <?xml version="1.0" encoding="UTF-8"?>
                                        <Person>
                                            <name>
                                                <%= name_input %>
                                            </name>
                                            <age>
                                                <%= age %>
                                            </age>
                                            <address>
                                                <%= address %>
                                            </address>
                                        </Person>

        xml_document.Save("C:\Users\CJMulingbayan\Documents\Visual Studio 2015\Projects\write_file\write_file\exported_files\" + name_input + ".xml")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        name_input = TextBox1.Text
        age = TextBox2.Text
        address = TextBox3.Text

        Dim person As New Person()
        person.name = name_input
        person.age = age
        person.address = address

        Dim output As String = JsonConvert.SerializeObject(person)
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\CJMulingbayan\Documents\Visual Studio 2015\Projects\write_file\write_file\exported_files\" + name_input + ".json", True)
        file.WriteLine(output)
        file.Close()
    End Sub
End Class
