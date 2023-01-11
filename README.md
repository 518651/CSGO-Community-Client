# CSGO开源启动器

技术栈:C# WPF UI



:warning:

> Readme待人补充



目前已实现:

前端：Index启动器首页

后台:   软件自更新



-----

## 启动器自更新配置

启动器会自动获取客户端写入的配置文件地址,读取XML文件进行更新.

更新XML文件配置详情:[AutoUpdater.NET](https://github.com/ravibpatel/AutoUpdater.NET)

基础配置(#号为注释,实际配置不能带#号):

`<?xml version="1.0" encoding="UTF-8"?>
<item>
  <version>2.0.0.0</version> 	# 声明目前最新版本 
  <url>https://rbsoft.org/downloads/AutoUpdaterTest.zip</url> # 最新版本启动器下载地址
  <changelog>https://github.com/ravibpatel/AutoUpdater.NET/releases</changelog> # 启动器升级公告内容
  <mandatory>false</mandatory> # 选填,如果内容为true,则用户可以跳过此版本,否则强制更新
</item>`