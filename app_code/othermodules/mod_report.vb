Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Module mod_report

    'Public Function setReportParams(ByVal oReport As ReportDocument, ByVal dbParams() As DictionaryEntry, ByVal ReportTitle As String) As String

    '    If oReport.Database.Tables.Count = 1 Then
    '        Dim oTable As Table = oReport.Database.Tables(0)
    '        Dim spName As String = oTable.LogOnInfo.TableName
    '        Dim Conn As New Data.SqlClient.SqlConnection(m_strConnString)

    '        Dim cmd As New Data.SqlClient.SqlCommand(spName, Conn)

    '        cmd.CommandType = CommandType.StoredProcedure
    '        For Each p In dbParams
    '            cmd.Parameters.Add(New SqlClient.SqlParameter(parameterName:=p.Key, value:=p.Value))
    '        Next

    '        Dim rdr As New Data.SqlClient.SqlDataAdapter(cmd)
    '        Dim tbl As New DataTable(oTable.Name.ToString)
    '        Try
    '            rdr.Fill(tbl)
    '            oTable.SetDataSource(tbl)

    '        Catch ex As Exception
    '            Return ex.Message
    '        End Try
    '    End If

    '    mod_report.setHeaderFooterInfo(oReport, ReportTitle)
    '    Return ""
    'End Function
    Private Function GetConnectionInfo() As CrystalDecisions.Shared.ConnectionInfo

        Dim objConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        Dim Parts = m_strConnString.Split(";").ToList
        Dim value = ""

        ' populate it
        objConnectionInfo.IntegratedSecurity = False

        value = (From O In Parts Where O.StartsWith("Data Source=")).SingleOrDefault.Replace("Data Source=", "")
        objConnectionInfo.ServerName = value
        value = (From O In Parts Where O.StartsWith("User ID=")).SingleOrDefault.Replace("User ID=", "")
        objConnectionInfo.UserID = value

        value = (From O In Parts Where O.Trim.StartsWith("Password=")).SingleOrDefault.Replace("Password=", "")
        objConnectionInfo.Password = value

        value = (From O In Parts Where O.StartsWith("Initial Catalog=")).SingleOrDefault.Replace("Initial Catalog=", "")
        objConnectionInfo.DatabaseName = value

        ' return object
        Return objConnectionInfo

    End Function

    Public Function setReportParams(ByRef oReport As ReportDocument, ByVal dbParams() As DictionaryEntry, ByVal ReportTitle As String) As String

        Dim crConnectionInfo = GetConnectionInfo()

        For Each aTable As Table In oReport.Database.Tables

            Dim crTableLogOnInfo = aTable.LogOnInfo

            crTableLogOnInfo.ConnectionInfo = crConnectionInfo
            aTable.ApplyLogOnInfo(crTableLogOnInfo)
            Dim strLocation = crConnectionInfo.DatabaseName & ".dbo." & aTable.Location.Substring(aTable.Location.LastIndexOf(".") + 1)

            aTable.Location = strLocation

            Dim ddd() As String = {"rptHeader.rpt", "rptFooter.rpt"}
            Dim ggg = ddd.ToList

            '// loop through all the sections to find all the report objects 
            For Each crSection As Section In oReport.ReportDefinition.Sections

                'crReportObjects = crSection.ReportObjects

                '//loop through all the report objects in there to find all subreports 
                For Each crReportObject As ReportObject In crSection.ReportObjects

                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                        Dim crSubreportObject = CType(crReportObject, CrystalDecisions.CrystalReports.Engine.SubreportObject)

                        If ggg.Contains(crSubreportObject.SubreportName) Then
                            mod_report.setHeaderFooterInfo(oReport, ReportTitle)

                        Else
                            '//open the subreport object and logon as for the general report 
                            Dim crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)
                            For Each bTable In crSubreportDocument.Database.Tables
                                crTableLogOnInfo = bTable.LogOnInfo
                                crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                                bTable.ApplyLogOnInfo(crTableLogOnInfo)
                                strLocation = crConnectionInfo.DatabaseName & ".dbo." & bTable.Location.Substring(bTable.Location.LastIndexOf(".") + 1)
                                bTable.Location = strLocation
                            Next bTable
                        End If
                    End If

                Next crReportObject
            Next crSection

        Next aTable

        ' get parameter fields from report
        'Dim crParameterFieldDefinitions = oReport.DataDefinition.ParameterFields

        '    ' Set the first parameter
        '    ' - Get the parameter, tell it to use the current values vs default value.
        '    ' - Tell it the parameter contains 1 discrete value vs multiple values.
        '    ' - Set the parameter's value.
        '    ' - Add it and apply it.
        '    ' - Repeat these statements for each parameter.
        '    '
        Dim dbParamList = dbParams.ToList

        For Each crParameterFieldLocation As ParameterFieldDefinition In oReport.DataDefinition.ParameterFields
            'cmd.Parameters.Add(New SqlClient.SqlParameter(parameterName:=p.Key, value:=p.Value))
            'Dim crParameterFieldLocation = crParameterFieldDefinitions.Item("@psindex")
            'If crParameterFieldLocation.ReportName = "" Then
            '    Dim crParameterValues = crParameterFieldLocation.CurrentValues
            '    Dim crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            '    Dim paramName = crParameterFieldLocation.Name
            '    crParameterDiscreteValue.Value = (From O In dbParamList Where O.Key = paramName Select O.Value).SingleOrDefault
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            'End If

            If crParameterFieldLocation.ReportName = "" Then
                Dim crParameterValues = New CrystalDecisions.Shared.ParameterValues
                Dim crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

                Dim paramName = crParameterFieldLocation.Name
                crParameterDiscreteValue.Value = (From O In dbParamList Where O.Key = paramName Select O.Value).SingleOrDefault

                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            End If
        Next

    End Function

    Private Function setHeaderFooterInfo(ByVal oReport As ReportDocument, ByVal ReportTitle As String) As Boolean

        Dim ds As New dsReportInfo
        With ds.dtReportInfo
            .AdddtReportInfoRow(settings.COMPANY_NAME, _
                                ReportTitle, _
                                "sub title", _
                                "", _
                                getLoggedOnUserID, _
                                "Run by: " & getLoggedOnUsername(), _
                                "Gibs v2.134", _
                                "@ 2010 Copyright Intteck Global Systems Limited. Unauthorised duplication prohibited.", _
                                "")
        End With

        Dim oSubRpt As ReportDocument
        oSubRpt = oReport.Subreports("rptHeader.rpt")

        If oSubRpt IsNot Nothing Then
            oSubRpt.SetDataSource(ds)
            '    With oSubRpt
            '        For Each oSection As Section In oSubRpt.ReportDefinition.Sections
            '            For Each oRptItem As ReportObject In oSection.ReportObjects
            '                Select Case oRptItem.Name
            '                    Case "txtCompany"
            '                        CType(oRptItem, TextObject).Text = "iDevWorks Technologies Ltd"
            '                    Case "txtReportTitle"
            '                        CType(oRptItem, TextObject).Text = Me.lbHeader.Text
            '                    Case "txtSubTitle"
            '                        CType(oRptItem, TextObject).Text = oReport.SummaryInfo.ReportSubject
            '                End Select
            '            Next
            '        Next
            '    End With
        End If

        oSubRpt = oReport.OpenSubreport("rptFooter.rpt")
        If oSubRpt IsNot Nothing Then
            oSubRpt.SetDataSource(ds)
            '    With oSubRpt
            '        For Each oSection As Section In oSubRpt.ReportDefinition.Sections
            '            For Each oRptItem As ReportObject In oSection.ReportObjects
            '                Select Case oRptItem.Name
            '                    Case "txtRunBy"
            '                        CType(oRptItem, TextObject).Text = "Run by: " & getLoggedOnUsername()
            '                    Case "txtVersion"
            '                        CType(oRptItem, TextObject).Text = "Gibs v2.134"
            '                    Case "txtFootNotes"
            '                        CType(oRptItem, TextObject).Text = "@ 2010 Copyright iDevWorks Technologies Limited. Unauthorised duplication prohibited."
            '                End Select
            '            Next
            '        Next
            '    End With
        End If
    End Function

    Private Function pushReportData(ByVal oReport As ReportDocument, ByVal rptDataSet As DataSet) As Boolean

        '   Called when a report is generated
        '   Calls SetData for the main report object
        '   Also calls SetData for any subreport objects


        SetData(oReport, rptDataSet)
        For Each oSubReport As ReportDocument In oReport.Subreports
            SetData(oSubReport, rptDataSet)
        Next
    End Function

    Private Function SetData(ByVal oReport As ReportDocument, ByVal rptDataSet As DataSet) As Boolean
        ' receives a DataSet and a report object (could be the 
        ' main object, could be a subreport object)

        ' loops through the report object's tables collection, 
        ' matches up the table name with the corresponding table
        ' name in the dataset, and sets the datasource accordingly

        ' This function eliminates the need for a developer to 
        ' know the specific table order in the report

        For Each oTable In oReport.Database.Tables
            oTable.SetDataSource(rptDataSet.Tables(oTable.Name.ToString()))
        Next
    End Function

End Module
