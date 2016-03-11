<?php
error_reporting(0);
//连接数据库
include("config.php");

//客户端请求IP列表
if($_GET['action']=='GetIPList' && isPrivateIp($_GET['IP']))
{
	//获取用户IP
	$user_IP = ($user_IP) ? $user_IP : $_SERVER["REMOTE_ADDR"]; 
	//获取现在时间
	$Nowtime = time();
	//计算30分钟前时间
	$Lasttime = time()- 60*30;
	//删除自己
	$sql = "DELETE FROM `userlist` WHERE `IPPrivate` = '" . $_GET['IP'] . "'";
	mysql_db_query($mysql_database,$sql);
	//插入新的自己
	$sql = "INSERT INTO `userlist` (`id`, `IPaddress`, `IPprivate`, `LastTime`) VALUES (NULL, '".$user_IP."', '".$_GET['IP']."', '$Nowtime');";
	mysql_db_query($mysql_database,$sql);
	//列表在线用户
	$sql = "SELECT * FROM `userlist` WHERE `IPaddress` = '$user_IP' && `LastTime` > $Lasttime";
	$result = mysql_db_query($mysql_database,$sql);
    // 获取查询结果
	
    while($row = mysql_fetch_array($result))
	{
			echo $row['IPprivate']."|";
	}
}

 /** 
 * 判断内网IP
 *
 * @param $ip
 *
 * @returns
 */
function isPrivateIp($ip) {
	//分割字符串
	$token  = strtok($ip, '.');
	//组合数组
	while ($token  !== false)
	{
	$strIP[] = $token;
	$token = strtok(".");

	}
	//判断IP地址是否合法
	if(count($strIP)!=4)
	{
		return false;
	}
	//判断是否为A类内网IP
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
	//判断是否为B类内网IP
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
	//判断是否为C类内网IP
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
//错误的IP地址
return false;
}   

?>