﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 12.0.0.0
//  
//     对此文件的更改可能会导致不正确的行为。此外，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace T4ProjectGenerator
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\zy\T4\T4ProjectGenerator\T4ProjectGenerator\Template\Common\MsSqlAccessBase.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class MsSqlAccessBase : Base
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using Dapper;\r\nusing System;\r\nusing System.Collections.Generic;\r\nusing System.Dat" +
                    "a;\r\n\r\nnamespace ");
            
            #line 11 "E:\zy\T4\T4ProjectGenerator\T4ProjectGenerator\Template\Common\MsSqlAccessBase.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Config.CommonNamespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public abstract class MsSqlAccessBase\r\n    {\r\n        #region 数据属性\r\n    " +
                    "    protected IDbContextComponent Context { get; private set; }\r\n        protect" +
                    "ed IDbConnection Connection { get; private set; }\r\n        protected IDbTransact" +
                    "ion Transaction { get; private set; }\r\n\r\n        protected abstract string Table" +
                    "Name { get; }\r\n        protected abstract string InsertString { get; }\r\n        " +
                    "protected abstract string UpdateString { get; }\r\n\r\n        public MsSqlAccessBas" +
                    "e(IDbContextComponent context)\r\n        {\r\n            this.Context = context;\r\n" +
                    "            this.Connection = this.Context.Connection;\r\n            this.Transac" +
                    "tion = this.Context.Transaction;\r\n        }\r\n\r\n        #endregion\r\n\r\n        #re" +
                    "gion 基础方法\r\n        /// <summary>\r\n        /// 添加或批量添加\r\n        /// </summary>\r\n " +
                    "       public virtual int Add<TEntity>(params TEntity[] entities)\r\n            w" +
                    "here TEntity : class\r\n        {\r\n            if (entities == null || entities.Le" +
                    "ngth <= 0)\r\n            {\r\n                throw new ArgumentNullException(\"enti" +
                    "ties\", \"操作数据不能为空\");\r\n            }\r\n            return this.Connection.Execute(t" +
                    "his.InsertString, entities, this.Transaction);\r\n        }\r\n\r\n        /// <summar" +
                    "y>\r\n        /// 单个添加\r\n        /// </summary>\r\n        public virtual TIdentity A" +
                    "dd<TEntity, TIdentity>(TEntity entity)\r\n            where TEntity : class\r\n     " +
                    "       where TIdentity : IConvertible\r\n        {\r\n            if (entity == null" +
                    ")\r\n            {\r\n                throw new ArgumentNullException(\"entity\", \"操作数" +
                    "据不能为空\");\r\n            }\r\n            string insertString = this.InsertString + \"" +
                    "; SELECT SCOPE_IDENTITY()\";\r\n            return this.Connection.ExecuteScalar<TI" +
                    "dentity>(insertString, entity, this.Transaction);\r\n        }\r\n\r\n        /// <sum" +
                    "mary>\r\n        /// 修改\r\n        /// </summary>\r\n        public virtual int Update" +
                    "<TEntity>(TEntity entity)\r\n            where TEntity : class\r\n        {\r\n       " +
                    "     if (entity == null)\r\n            {\r\n                throw new ArgumentNullE" +
                    "xception(\"entity\", \"操作数据不能为空\");\r\n            }\r\n            return this.Connecti" +
                    "on.Execute(this.UpdateString, entity, this.Transaction);\r\n        }\r\n\r\n        /" +
                    "// <summary>\r\n        /// 删除\r\n        /// </summary>\r\n        public virtual int" +
                    " Delete(Expr expr)\r\n        {\r\n            DynamicParameters parameters = new Dy" +
                    "namicParameters();\r\n            string deleteString = string.Format(MsSqlConfig." +
                    "DELETE_FORMAT, this.TableName, expr.ToWhere(parameters));\r\n            return th" +
                    "is.Connection.Execute(deleteString, parameters, this.Transaction);\r\n        }\r\n\r" +
                    "\n        /// <summary>\r\n        /// 判断存在\r\n        /// </summary>\r\n        public" +
                    " virtual bool IsExist(Expr expr)\r\n        {\r\n            DynamicParameters param" +
                    "eters = new DynamicParameters();\r\n            string selectString = string.Forma" +
                    "t(MsSqlConfig.SELECT_COUNT_FORMAT, this.TableName, expr.ToWhere(parameters));\r\n " +
                    "           int result = this.Connection.ExecuteScalar<int>(selectString, paramet" +
                    "ers, this.Transaction);\r\n            return result > 0;\r\n        }\r\n\r\n        //" +
                    "/ <summary>\r\n        /// 总数量\r\n        /// </summary>\r\n        public virtual int" +
                    " GetCount()\r\n        {\r\n            DynamicParameters parameters = new DynamicPa" +
                    "rameters();\r\n            string selectString = string.Format(MsSqlConfig.SELECT_" +
                    "ALL_COUNT_FORMAT, this.TableName);\r\n            return this.Connection.ExecuteSc" +
                    "alar<int>(selectString, transaction: this.Transaction);\r\n        }\r\n\r\n        //" +
                    "/ <summary>\r\n        /// 查询条件数量\r\n        /// </summary>\r\n        public virtual " +
                    "int GetCount(Expr expr)\r\n        {\r\n            DynamicParameters parameters = n" +
                    "ew DynamicParameters();\r\n            string selectString = string.Format(MsSqlCo" +
                    "nfig.SELECT_COUNT_FORMAT, this.TableName, expr.ToWhere(parameters));\r\n          " +
                    "  return this.Connection.ExecuteScalar<int>(selectString, parameters, this.Trans" +
                    "action);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询实体\r\n        /// </su" +
                    "mmary>\r\n        public virtual TEntity Get<TEntity>(Expr expr)\r\n            wher" +
                    "e TEntity : class\r\n        {\r\n            DynamicParameters parameters = new Dyn" +
                    "amicParameters();\r\n            string selectString = string.Format(MsSqlConfig.S" +
                    "ELECT_TOP_FORMAT, this.TableName, expr.ToWhere(parameters), 1);\r\n            ret" +
                    "urn this.Connection.QueryFirstOrDefault<TEntity>(selectString, parameters, this." +
                    "Transaction);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询实体\r\n        ///" +
                    " </summary>\r\n        public virtual TEntity Get<TEntity>(Expr expr, OrderByExpr " +
                    "orderBy)\r\n            where TEntity : class\r\n        {\r\n            DynamicParam" +
                    "eters parameters = new DynamicParameters();\r\n            string selectString = s" +
                    "tring.Format(MsSqlConfig.SELECT_TOP_ORDER_BY_FORMAT,\r\n                this.Table" +
                    "Name, expr.ToWhere(parameters), 1, orderBy.ToOrderBy());\r\n            return thi" +
                    "s.Connection.QueryFirstOrDefault<TEntity>(selectString, parameters, this.Transac" +
                    "tion);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询列表\r\n        /// </summ" +
                    "ary>\r\n        public virtual IEnumerable<TEntity> GetList<TEntity>()\r\n          " +
                    "  where TEntity : class\r\n        {\r\n            string selectString = string.For" +
                    "mat(MsSqlConfig.SELECT_ALL_FORMAT, this.TableName);\r\n            return this.Con" +
                    "nection.Query<TEntity>(selectString, transaction: this.Transaction);\r\n        }\r" +
                    "\n\r\n        /// <summary>\r\n        /// 查询列表\r\n        /// </summary>\r\n        publ" +
                    "ic virtual IEnumerable<TEntity> GetList<TEntity>(Expr expr)\r\n            where T" +
                    "Entity : class\r\n        {\r\n            DynamicParameters parameters = new Dynami" +
                    "cParameters();\r\n            string selectString = string.Format(MsSqlConfig.SELE" +
                    "CT_FORMAT, this.TableName, expr.ToWhere(parameters), 1);\r\n            return thi" +
                    "s.Connection.Query<TEntity>(selectString, parameters, this.Transaction);\r\n      " +
                    "  }\r\n\r\n        /// <summary>\r\n        /// 查询列表\r\n        /// </summary>\r\n        " +
                    "public virtual IEnumerable<TEntity> GetList<TEntity>(Expr expr, int top)\r\n      " +
                    "      where TEntity : class\r\n        {\r\n            DynamicParameters parameters" +
                    " = new DynamicParameters();\r\n            string selectString = string.Format(MsS" +
                    "qlConfig.SELECT_TOP_FORMAT, this.TableName, expr.ToWhere(parameters), top);\r\n   " +
                    "         return this.Connection.Query<TEntity>(selectString, parameters, this.Tr" +
                    "ansaction);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询列表\r\n        /// <" +
                    "/summary>\r\n        public virtual IEnumerable<TEntity> GetList<TEntity>(Expr exp" +
                    "r, int top, OrderByExpr orderBy)\r\n            where TEntity : class\r\n        {\r\n" +
                    "            DynamicParameters parameters = new DynamicParameters();\r\n           " +
                    " string selectString = string.Format(MsSqlConfig.SELECT_TOP_ORDER_BY_FORMAT,\r\n  " +
                    "              this.TableName, expr.ToWhere(parameters), top, orderBy.ToOrderBy()" +
                    ");\r\n            return this.Connection.Query<TEntity>(selectString, parameters, " +
                    "this.Transaction);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询列表\r\n      " +
                    "  /// </summary>\r\n        public virtual IEnumerable<TEntity> GetList<TEntity>(E" +
                    "xpr expr, OrderByExpr orderBy)\r\n            where TEntity : class\r\n        {\r\n  " +
                    "          DynamicParameters parameters = new DynamicParameters();\r\n            s" +
                    "tring selectString = string.Format(MsSqlConfig.SELECT_ORDER_BY_FORMAT,\r\n        " +
                    "        this.TableName, expr.ToWhere(parameters), orderBy.ToOrderBy());\r\n       " +
                    "     return this.Connection.Query<TEntity>(selectString, parameters, this.Transa" +
                    "ction);\r\n        }\r\n\r\n        /// <summary>\r\n        /// 查询列表\r\n        /// </sum" +
                    "mary>\r\n        public virtual IEnumerable<TEntity> GetList<TEntity>(Expr expr, O" +
                    "rderByExpr orderBy, int startPage, int endPage)\r\n            where TEntity : cla" +
                    "ss\r\n        {\r\n            DynamicParameters parameters = new DynamicParameters(" +
                    ");\r\n            string selectString = string.Format(MsSqlConfig.SELECT_PAGE_FORM" +
                    "AT,\r\n                this.TableName, expr.ToWhere(parameters), orderBy.ToOrderBy" +
                    "(), startPage, endPage);\r\n            return this.Connection.Query<TEntity>(sele" +
                    "ctString, parameters, this.Transaction);\r\n        }\r\n        #endregion\r\n\r\n    }" +
                    "\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
