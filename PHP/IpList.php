<?php
error_reporting(0);
//�������ݿ�
include("config.php");

//�ͻ�������IP�б�
if($_GET['action']=='GetIPList' && isPrivateIp($_GET['IP']))
{
	//��ȡ�û�IP
	$user_IP = ($user_IP) ? $user_IP : $_SERVER["REMOTE_ADDR"]; 
	//��ȡ����ʱ��
	$Nowtime = time();
	//����30����ǰʱ��
	$Lasttime = time()- 60*30;
	//ɾ���Լ�
	$sql = "DELETE FROM `userlist` WHERE `IPPrivate` = '" . $_GET['IP'] . "'";
	mysql_db_query($mysql_database,$sql);
	//�����µ��Լ�
	$sql = "INSERT INTO `userlist` (`id`, `IPaddress`, `IPprivate`, `LastTime`) VALUES (NULL, '".$user_IP."', '".$_GET['IP']."', '$Nowtime');";
	mysql_db_query($mysql_database,$sql);
	//�б������û�
	$sql = "SELECT * FROM `userlist` WHERE `IPaddress` = '$user_IP' && `LastTime` > $Lasttime";
	$result = mysql_db_query($mysql_database,$sql);
    // ��ȡ��ѯ���
	
    while($row = mysql_fetch_array($result))
	{
			echo $row['IPprivate']."|";
	}
}

 /** 
 * �ж�����IP
 *
 * @param $ip
 *
 * @returns
 */
function isPrivateIp($ip) {
	//�ָ��ַ���
	$token  = strtok($ip, '.');
	//�������
	while ($token  !== false)
	{
	$strIP[] = $token;
	$token = strtok(".");

	}
	//�ж�IP��ַ�Ƿ�Ϸ�
	if(count($strIP)!=4)
	{
		return false;
	}
	//�ж��Ƿ�ΪA������IP
	if($strIP[0] == '10')
	{
		if($strIP[1]>=0 && $strIP[1] <= 255)
		{
			if($strIP[2]>=0 && $strIP[2] <= 255)
			{
				if($strIP[3]>=0 && $strIP[3] <= 255)
				{
					return true;
				}
			}
		}
		return false;
	}
	//�ж��Ƿ�ΪB������IP
	if($strIP[0] == '172')
	{
		if($strIP[1] >= 16 && $strIP[1] <= 31)
		{
			if($strIP[2]>=0 && $strIP[2] <= 255)
			{
				if($strIP[3]>=0 && $strIP[3] <= 255)
				{
					return true;
				}
			}
		}
		return false;
	}
	//�ж��Ƿ�ΪC������IP
	if($strIP[0] == '192')
	{
		if($strIP[1] == '168')
		{
			if($strIP[2]>=0 && $strIP[2] <= 255)
			{
				if($strIP[3]>=0 && $strIP[3] <= 255)
				{
					return true;
				}
			}
		}
		return false;
	}
//�����IP��ַ
return false;
}   

?>