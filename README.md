# EtherAPI


КАК юзать

скачивам node.js

в cmd пишем: npm install -g ethereumjs-{название, например testEther}
ждемс

далее для проверки вводим {как назвали, например testEther}
...выдаст адреса и приватные ключи

все, etherjs работает!

по проекту:

....api/Eth   -  выводит все кошельки и приватные ключи

....api/Eth/{адресс}    -   выводит количество эфира в wei и eth

....api/Eth    post по переводу между кошельками можно проверить например в postman

от отправителя требуется его приватный ключ, их смотрим в ноде(см выше)

ПРИМЕР
{
"From_PrivateKey":"cdcde7b15e75ece7cef67c06042c31cc40d35057d64f5b44fa89bcd74c39bb76",
"To":"0x60a922d16f13e212783bd0e0ea565389c12e4a2a",
"Amount":20
}

20 - сумма в wei