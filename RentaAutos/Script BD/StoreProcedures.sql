use DB_RENTA_AUTO ;
--------------------------
Create Procedure ListarAutomovilesActivos_SP 
as 
begin
	Select * 
	From AUTOMOVIL
	Where ACTIVO = 1
end
;
--------------------------
Create Procedure ListarAutomovilesDisponibles_SP 
as 
begin
	Select A.ID_AUTOMOVIL,A.GAMA ,A.PRECIO, M.NOMBRE_MARCA, T.NOMBRE_TIPO
	From dbo.AUTOMOVIL As A
	Join dbo.MARCA as M  On A.ID_MARCA = M.ID_MARCA
	Join dbo.TIPO as T On A.ID_TIPO = T.ID_TIPO
	Where OCUPADO = 0
end
;
--------------------------
Create Procedure SoftDeleteAutomovilById_SP (
@ID_AUTOMOVIL BigInt
)
as 
Begin
	Update dbo.AUTOMOVIL
	Set ACTIVO = 0
	Where ID_AUTOMOVIL = @ID_AUTOMOVIL
end
;
--------------------------
Create Procedure ListarMarcasActivas_SP 
as 
Begin
	Select ID_MARCA, NOMBRE_MARCA
	From dbo.MARCA
	Where ACTIVO = 1
end
;
--------------------------
Create Procedure SoftDeleteMarcaById_SP (
@ID_MARCA BigInt
)
as 
Begin
	Update dbo.MARCA
	Set ACTIVO = 0
	Where ID_MARCA = @ID_MARCA
end
;
--------------------------
Create Procedure ListarRolesActivos_SP 
as 
Begin
	Select ID_ROL,NOMBRE_ROL
	From dbo.ROL
	Where ACTIVO = 1
end
;
--------------------------
Create Procedure SoftDeleteRolById_SP (
@ID_ROL BigInt
)
as 
Begin
	Update dbo.ROL
	Set ACTIVO = 0
	Where ID_ROL = ID_ROL
end
;
--------------------------
Create Procedure ListarTiposActivos_SP 
as 
Begin
	Select ID_TIPO, NOMBRE_TIPO
	From dbo.TIPO
	Where ACTIVO = 1
end
;
--------------------------
Create Procedure SoftDeleteTipoById_SP (
@ID_TIPO BigInt
)
as 
Begin
	Update dbo.TIPO
	Set ACTIVO = 0
	Where ID_TIPO = ID_TIPO
end
;
--------------------------
Create Procedure ListarUsuarios_SP 
as 
Begin
	Select ID_USUARIO, USUARIO, CONTRASENA, NOMBRE_USUARIO, 
	       APELLIDO_USUARIO, FECHA_NACIMIENTO, DIRECCION, 
	       TELEFONO, CORREO, R.NOMBRE_ROL 
	From dbo.USUARIO As U
	Join dbo.ROL as R On U.ID_ROL = R.ID_ROL 
	
end
;
--------------------------
Create Procedure ListarRentas_SP 
as 
Begin
	Select R.ID_RENTA, R.PRECIO, R.FECHA_ALQUILER, 
	       A.GAMA, M.NOMBRE_MARCA, T.NOMBRE_TIPO,
	       U.NOMBRE_USUARIO, U.APELLIDO_USUARIO 
	From dbo.RENTA     As R
	Join dbo.AUTOMOVIL As A On R.ID_AUTOMOVIL = A.ID_AUTOMOVIL
	Join dbo.USUARIO   As U On R.ID_USUARIO   = U.ID_USUARIO
	Join dbo.MARCA     As M On A.ID_MARCA = M.ID_MARCA
	Join dbo.TIPO      As T On A.ID_TIPO = T.ID_TIPO
	
end
;
--------------------------
