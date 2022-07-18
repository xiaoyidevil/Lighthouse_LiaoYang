/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80029
 Source Host           : localhost:3306
 Source Schema         : iws_db

 Target Server Type    : MySQL
 Target Server Version : 80029
 File Encoding         : 65001

 Date: 17/07/2022 14:27:59
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for m_demander
-- ----------------------------
DROP TABLE IF EXISTS `m_demander`;
CREATE TABLE `m_demander`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `DemanderId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0' COMMENT '需求方编号',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '需求方企业名称',
  `CompanyAddress` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '需求方企业地址',
  `PostCode1` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮政编号1',
  `PostCode2` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮政编号2',
  `Website` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '企业网址',
  `NatureEnterprise` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '企业性质',
  `Tel` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系电话',
  `Fax` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '传真',
  `IsDelete` int(0) NOT NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '需求方基本信息' ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for m_jurisdiction
-- ----------------------------
DROP TABLE IF EXISTS `m_jurisdiction`;
CREATE TABLE `m_jurisdiction`  (
  `JurisdictionId` int(0) NOT NULL AUTO_INCREMENT COMMENT '权限ID',
  `JurisdictionLevel` int(0) NOT NULL COMMENT '权限层级',
  `ParentID` int(0) NOT NULL COMMENT '父级权限ID',
  `JurisdictionName` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限名称',
  `JurisdictionPath` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '权限路径',
  `Icon` tinyint(0) NULL DEFAULT 0 COMMENT '图标',
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `IsDelete` tinyint(0) NULL DEFAULT 0 COMMENT '物理删除标志',
  PRIMARY KEY (`JurisdictionId`, `JurisdictionLevel`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 28 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '权限表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for m_material
-- ----------------------------
DROP TABLE IF EXISTS `m_material`;
CREATE TABLE `m_material`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `MaterialId` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '物料编号',
  `MaterialName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '物料名称',
  `MaterialEnglishName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '物料英文名称',
  `SpecificationsModel` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '规格型号',
  `Material` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '材质',
  `MaterialKind` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '物料类别',
  `Unit` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '计量单位',
  `IsDelete` int(0) NOT NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '物料表' ROW_FORMAT = Dynamic;


-- ----------------------------
-- Table structure for m_role
-- ----------------------------
DROP TABLE IF EXISTS `m_role`;
CREATE TABLE `m_role`  (
  `RoleId` int(0) NOT NULL AUTO_INCREMENT COMMENT '角色ID',
  `RoleName` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '角色名称',
  `RoleDesc` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '角色描述',
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `IsDelete` int(0) NULL DEFAULT 0 COMMENT '物理删除标志',
  PRIMARY KEY (`RoleId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色表' ROW_FORMAT = Dynamic;


-- ----------------------------
-- Table structure for m_role_jurisdiction
-- ----------------------------
DROP TABLE IF EXISTS `m_role_jurisdiction`;
CREATE TABLE `m_role_jurisdiction`  (
  `RoleId` int(0) NOT NULL AUTO_INCREMENT COMMENT '角色ID',
  `JurisdictionId` int(0) NOT NULL COMMENT '权限ID',
  `JurisdictionLevel` int(0) NOT NULL COMMENT '权限ID',
  `ParentID` int(0) NOT NULL COMMENT '父级权限ID',
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` timestamp(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `IsDelete` tinyint(0) NULL DEFAULT 0 COMMENT '物理删除标志',
  PRIMARY KEY (`RoleId`, `JurisdictionId`, `JurisdictionLevel`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '角色权限表' ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for m_supplier
-- ----------------------------
DROP TABLE IF EXISTS `m_supplier`;
CREATE TABLE `m_supplier`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `SupplierId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '供应商编号',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '供应商企业名称',
  `CompanyAddress` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '供应商企业地址',
  `PostCode1` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮政编号1',
  `PostCode2` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮政编号2',
  `Website` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '企业网址',
  `NatureEnterprise` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '企业性质',
  `Tel` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '联系电话',
  `Fax` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '传真',
  `IsDelete` int(0) NOT NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '供应商基本信息' ROW_FORMAT = Dynamic;


-- ----------------------------
-- Table structure for m_system_parameter
-- ----------------------------
DROP TABLE IF EXISTS `m_system_parameter`;
CREATE TABLE `m_system_parameter`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Code` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value1` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value2` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value3` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value4` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Value5` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Remarks` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDelete` int(0) NULL DEFAULT NULL,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for m_user
-- ----------------------------
DROP TABLE IF EXISTS `m_user`;
CREATE TABLE `m_user`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户账号',
  `UserName` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '用户名称',
  `Password` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '密码',
  `RoleId` int(0) NOT NULL COMMENT '角色',
  `Telephone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '电话',
  `IdCard` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '身份证',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '单位名称',
  `Age` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '年龄',
  `Sex` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '性别',
  `Email` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '邮箱',
  `IsDelete` int(0) NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 50 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '用户基本信息表' ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for m_vehicle
-- ----------------------------
DROP TABLE IF EXISTS `m_vehicle`;
CREATE TABLE `m_vehicle`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT COMMENT '角色ID',
  `VehicleNumber` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '车牌号码',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '经营企业名称',
  `BrandModel` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '品牌型号',
  `Color` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '车身颜色',
  `Weight` double(10, 2) NULL DEFAULT NULL COMMENT '车身重量（公斤）',
  `FullLoadWeight` double(10, 2) NULL DEFAULT NULL COMMENT '满载重量（公斤）',
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP,
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `IsDelete` int(0) NULL DEFAULT 0 COMMENT '物理删除标志',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '车辆基本信息表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of m_vehicle
-- ----------------------------


-- ----------------------------
-- Table structure for t_approval
-- ----------------------------
DROP TABLE IF EXISTS `t_approval`;
CREATE TABLE `t_approval`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT COMMENT '审批序号',
  `RegistrationId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场登记单号',
  `Sequence` int(0) NULL DEFAULT NULL COMMENT '审批履历序号',
  `Comment` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '审批者评论',
  `IsDelete` int(0) NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 15 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '入场审批' ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for t_registration
-- ----------------------------
DROP TABLE IF EXISTS `t_registration`;
CREATE TABLE `t_registration`  (
  `RegistrationId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '入场登记单号',
  `CompanyId` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '公司编号',
  `CompanyName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '公司名称',
  `UserId` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '人员编号',
  `UserName` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '人员名称',
  `VehicleNumber` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '车牌号',
  `EntranceGate` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场大门',
  `EntranceStartDate` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场开始日期',
  `EntranceStartTime` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场开始时段',
  `EntranceEndDate` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场结束日期',
  `EntranceEndTime` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场结束时段',
  `Overseer` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '监工单位',
  `AdmisionType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场类型',
  `Reason` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场事由',
  `Accption` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '接受单位',
  `CurrentState` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '当前审批状态',
  `IsDelete` int(0) NOT NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`RegistrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci COMMENT = '入场登记' ROW_FORMAT = Dynamic;



-- ----------------------------
-- Table structure for t_vehicleweighing
-- ----------------------------
DROP TABLE IF EXISTS `t_vehicleweighing`;
CREATE TABLE `t_vehicleweighing`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `RegistrationId` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '入场登记单号',
  `WeightingDate` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '上称日期',
  `WeightingSeq` int(0) NULL DEFAULT NULL COMMENT '上称序号',
  `Weighting` double(20, 2) NULL DEFAULT NULL COMMENT '上称重量',
  `WeightType` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL COMMENT '称重类型',
  `IsDelete` int(0) NULL DEFAULT 0,
  `CreateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `CreateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `UpdateUser` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT 'SYSTEM',
  `UpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
  `Remark` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;



SET FOREIGN_KEY_CHECKS = 1;
