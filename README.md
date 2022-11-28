# Cara Crachá

Aplicação MVC que tira fotos utilizando a webcam do computador ou câmera do celular, mostra o resultado da captura antes de fazer o upload para pasta do servidor

<br>

## Atenção aos itens para o deploy:

1.  Dar acesso de gravação para o usuário padrão do IIS na pasta “wwwroot\Files”

2.  Para acessar os recursos do navegador como a câmera, é necessário o uso do protocolo HTTPS. Sendo assim o IIS deve ter um certificado SSL.

<br>

## Certificado SSL para o IIS

Caso você não tenha o certificado, pode criar um para testes utilizando os comandos em powershell. 

Para esse comando e necessário executar o powershell em modo admin.

<pre>
    <code>New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "local.nomesite.com.br" -FriendlyName "Nomesite" -NotAfter (Get-Date).AddYears(10) 
    </code>
</pre>

<br>

![Visão](https://github.com/jucelinopinheiro/caracracha/blob/main/capa/CaraCracha.png)
