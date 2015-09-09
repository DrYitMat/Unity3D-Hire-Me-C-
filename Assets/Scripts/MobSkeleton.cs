using UnityEngine;
using System.Collections;

public class MobSkeleton : Mob {
	private static MobTypes baseType = MobTypes.Skeleton;

	private SkeletonTypes skeletonType;

	public SkeletonTypes SkeletonType {
		get {
			return skeletonType;
		}
		set {
			skeletonType = value;
		}
	}
	
	public MobSkeleton(string skeleName, Stats skeleStats, bool pkUp, SkeletonTypes skeleType, AttackTypes attkType) : base(skeleName, skeleStats, pkUp, attkType, baseType){

	}
}
