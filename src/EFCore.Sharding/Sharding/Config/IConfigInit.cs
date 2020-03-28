﻿using System;

namespace EFCore.Sharding
{
    /// <summary>
    /// 配置初始化
    /// </summary>
    public interface IConfigInit
    {
        /// <summary>
        /// 设置实体的程序集
        /// 注:使用模糊匹配获取,例如传入"Entity",则将会扫描所有名字包含"Entity"的程序集
        /// 注:实体类必须拥有System.ComponentModel.DataAnnotations.Schema.TableAttribute特性
        /// </summary>
        /// <param name="entityAssemblyNames">程序集名</param>
        /// <returns></returns>
        IConfigInit SetEntityAssembly(params string[] entityAssemblyNames);

        /// <summary>
        /// 添加抽象数据库
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="absDbName">抽象数据库名</param>
        /// <returns></returns>
        IConfigInit AddAbsDb(
            DatabaseType dbType,
            string absDbName = ShardingConfig.DefaultAbsDbName);

        /// <summary>
        /// 添加物理数据库组
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <param name="absDbName">抽象数据库名</param>
        /// <returns></returns>
        IConfigInit AddPhysicDbGroup(
            string groupName = ShardingConfig.DefaultDbGourpName,
            string absDbName = ShardingConfig.DefaultAbsDbName);

        /// <summary>
        /// 添加物理数据库
        /// </summary>
        /// <param name="opType">读写类型,同时读写填写ReadWriteType.Read | ReadWriteType.Write</param>
        /// <param name="conString">连接字符串</param>
        /// <param name="groupName">数据库组名</param>
        /// <returns></returns>
        IConfigInit AddPhysicDb(
            ReadWriteType opType,
            string conString,
            string groupName = ShardingConfig.DefaultDbGourpName);

        /// <summary>
        /// 添加物理数据表
        /// </summary>
        /// <typeparam name="TEntity">对应抽象表类型</typeparam>
        /// <param name="physicTableName">物理表明</param>
        /// <param name="groupName">数据库组名</param>
        /// <returns></returns>
        IConfigInit AddPhysicTable<TEntity>(
            string physicTableName,
            string groupName = ShardingConfig.DefaultDbGourpName);

        /// <summary>
        /// 设置分表规则
        /// </summary>
        /// <typeparam name="TEntity">对应抽象表类型</typeparam>
        /// <param name="shardingRule">具体分表规则</param>
        /// <param name="absDbName">抽象数据库名</param>
        /// <returns></returns>
        IConfigInit SetShardingRule<TEntity>(
            AbsShardingRule<TEntity> shardingRule,
            string absDbName = ShardingConfig.DefaultAbsDbName);

        /// <summary>
        /// 通过日期自动扩容
        /// 优点:即自动定时按照建表,无需数据迁移
        /// </summary>
        /// <typeparam name="TEntity">对应抽象表类型</typeparam>
        /// <param name="startTime">开始时间</param>
        /// <param name="expandByDateMode">扩容模式</param>
        /// <param name="groupName">数据库组名</param>
        /// <returns></returns>
        IConfigInit AutoExpandByDate<TEntity>(
            DateTime startTime,
            ExpandByDateMode expandByDateMode,
            string groupName = ShardingConfig.DefaultDbGourpName);
    }
}
