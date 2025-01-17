﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.QuerySpec;
using Doc2PdfApi.HelperClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses.DTOProjectionHelpers;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Dtos.Persistence
{

	/// <summary>Static class for (extension) methods for fetching and projecting instances of Dtos.DtoClasses.PdfSync from the entity model.</summary>
	public static partial class PdfSyncPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync> _compiledProjector = CreateProjectionFunc().Compile();
		/// <summary>Linq specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToPdfSync(System.Linq.IQueryable{Doc2PdfApi.EntityClasses.PdfSyncEntity})"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="CreateProjectionFunc"/></param>
		/// <remarks>Linq specific</remarks>
		static partial void GetAdjustmentsForProjectToPdfSync(ref System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync>> projectionAdjustments);
		/// <summary>QuerySpec specific partial method for obtaining projection adjustments for the projection method <see cref="ProjectToPdfSync(EntityQuery{Doc2PdfApi.EntityClasses.PdfSyncEntity}, Doc2PdfApi.FactoryClasses.QueryFactory)"/></summary>
		/// <param name="projectionAdjustments">Set this argument in an implementation of this partial method to a projection lambda similar to the generated projection in <see cref="ProjectToPdfSync(EntityQuery{Doc2PdfApi.EntityClasses.PdfSyncEntity}, Doc2PdfApi.FactoryClasses.QueryFactory)"/></param>
		/// <remarks>QuerySpec specific</remarks>
		static partial void GetAdjustmentsForProjectToPdfSyncQs(ref System.Linq.Expressions.Expression<Func<Dtos.DtoClasses.PdfSync>> projectionAdjustments);
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static PdfSyncPersistence() { }
	
		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.PdfSync which instances are projected from the results of the specified baseQuery, which returns Doc2PdfApi.EntityClasses.PdfSyncEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve Dtos.DtoClasses.PdfSync instances</returns>
		public static IQueryable<Dtos.DtoClasses.PdfSync> ProjectToPdfSync(this IQueryable<Doc2PdfApi.EntityClasses.PdfSyncEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}

		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.PdfSync which instances are projected from the results of the specified baseQuery using QuerySpec, which returns Doc2PdfApi.EntityClasses.PdfSyncEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <param name="qf">The query factory used to create baseQuery.</param>
		/// <returns>DynamicQuery to retrieve Dtos.DtoClasses.PdfSync instances</returns>
		public static DynamicQuery<Dtos.DtoClasses.PdfSync> ProjectToPdfSync(this EntityQuery<Doc2PdfApi.EntityClasses.PdfSyncEntity> baseQuery, Doc2PdfApi.FactoryClasses.QueryFactory qf)
		{
			System.Linq.Expressions.Expression<Func<Dtos.DtoClasses.PdfSync>> projectionAdjustments = null;
			GetAdjustmentsForProjectToPdfSyncQs(ref projectionAdjustments);
			return qf.Create()
				.From(baseQuery.Select(Projection.Full).As("__BQ"))
				.Select(LinqUtils.MergeProjectionAdjustmentsIntoProjection(() => new Dtos.DtoClasses.PdfSync()
				{
					DateCreate = PdfSyncFields.DateCreate.Source("__BQ").ToValue<Nullable<System.DateTime>>(),
					DateModify = PdfSyncFields.DateModify.Source("__BQ").ToValue<Nullable<System.DateTime>>(),
					ErrorMessage = PdfSyncFields.ErrorMessage.Source("__BQ").ToValue<System.String>(),
					FilePath = PdfSyncFields.FilePath.Source("__BQ").ToValue<System.String>(),
					Id = PdfSyncFields.Id.Source("__BQ").ToValue<System.String>(),
					JsonData = PdfSyncFields.JsonData.Source("__BQ").ToValue<System.String>(),
					Name = PdfSyncFields.Name.Source("__BQ").ToValue<System.String>(),
					Status = PdfSyncFields.Status.Source("__BQ").ToValue<System.String>(),
					UserCreate = PdfSyncFields.UserCreate.Source("__BQ").ToValue<System.String>(),
					UserModify = PdfSyncFields.UserModify.Source("__BQ").ToValue<System.String>(),
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegionQS_PdfSync 
	// __LLBLGENPRO_USER_CODE_REGION_END 
				}, projectionAdjustments, false));
		}

		/// <summary>Extension method which produces a projection to Dtos.DtoClasses.PdfSync which instances are projected from the Doc2PdfApi.EntityClasses.PdfSyncEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>Doc2PdfApi.EntityClasses.PdfSyncEntity instance created from the specified entity instance</returns>
		public static Dtos.DtoClasses.PdfSync ProjectToPdfSync(this Doc2PdfApi.EntityClasses.PdfSyncEntity entity)
		{
			return _compiledProjector(entity);
		}

		private static System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync>> CreateProjectionFunc()
		{
			System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync>> mainProjection = p__0 => new Dtos.DtoClasses.PdfSync()
			{
				DateCreate = p__0.DateCreate,
				DateModify = p__0.DateModify,
				ErrorMessage = p__0.ErrorMessage,
				FilePath = p__0.FilePath,
				Id = p__0.Id,
				JsonData = p__0.JsonData,
				Name = p__0.Name,
				Status = p__0.Status,
				UserCreate = p__0.UserCreate,
				UserModify = p__0.UserModify,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_PdfSync 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
			System.Linq.Expressions.Expression<Func<Doc2PdfApi.EntityClasses.PdfSyncEntity, Dtos.DtoClasses.PdfSync>> projectionAdjustments = null;
			GetAdjustmentsForProjectToPdfSync(ref projectionAdjustments);
			return LinqUtils.MergeProjectionAdjustmentsIntoProjection(mainProjection, projectionAdjustments, true);
		}
	}
}


