<?php
$fp = fopen('ip.txt', "r");
$ip = fread($fp,filesize('ip.txt'));
fclose($fp);
header ("Location: http://".$ip);
?>