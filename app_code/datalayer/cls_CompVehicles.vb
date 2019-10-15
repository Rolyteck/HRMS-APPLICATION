
Public Class cls_compVehicles
    Dim db As New Hrms3.hrms3dbDataContext
    Public Function Delete(ByVal vehicleID As String) As ResponseInfo
        Try
            Dim row As Hrms3.HRCompVehicle = (From B In db.HRCompVehicles Where B.VehicleID = vehicleID).ToList()(0)
            db.HRCompVehicles.DeleteOnSubmit(row)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function
    Public Function Insert(ByVal G As Hrms3.HRCompVehicle) As ResponseInfo
        Try
            db.HRCompVehicles.InsertOnSubmit(G)
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function Update(ByVal G As Hrms3.HRCompVehicle) As ResponseInfo
        Try
            db.SubmitChanges()
            Return mod_main._GetResponseStruct(ErrCodeEnum.NO_ERROR, 1, 0)
        Catch ex As Exception
            Return mod_main._GetResponseStruct(ErrCodeEnum.GENERIC_ERROR, , , ex.Message)
        End Try
    End Function

    Public Function SelectThis(ByVal vehicleID As String) As Hrms3.HRCompVehicle
        Try
            Return (From B In db.HRCompVehicles Where B.VehicleID = vehicleID).ToList()(0)
        Catch ex As Exception
            Return New Hrms3.HRCompVehicle
        End Try
    End Function
    Public Function SelectWhereEmployee(ByVal EmployeeID As String) As List(Of Hrms3.HRCompVehicle)
        Try
            Return (From DN In db.HRCompVehicles Where DN.EmployeeID = EmployeeID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRCompVehicle)
        End Try
    End Function
    Public Function SelectAll() As List(Of Hrms3.HRCompVehicle)
        Try
            Return (From P In db.HRCompVehicles Order By P.VehicleID).ToList()
        Catch ex As Exception
            Return New List(Of Hrms3.HRCompVehicle)
        End Try
    End Function
End Class
