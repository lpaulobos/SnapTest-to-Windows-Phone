<?php 

    $login = $_POST['login'];
    $senha = ($_POST['senha']);

    $connect = mysqli_connect("mysql.hostinger.com.br","u913192727_admin","lpaulobos","u913192727_mydb");



	        $verifica = mysqli_query($connect,"SELECT * FROM usuarios WHERE login = '$login' AND senha = '$senha'");
                if (mysqli_num_rows($verifica,true)<=0){

                    echo "Login e/ou senha incorretos";

                }else
				{
					echo"Sucesso ao logar";				
				}
       
		mysqli_close($connect);
?>