select * from EMP

create or alter procedure GeneratePayslip(@EMPNO int)
AS
BEGIN
	declare @basic_sal DECIMAL
    select @basic_sal=SAL from emp where empno=@EMPNO
    declare @HRA DECIMAL
    declare @DA DECIMAL
    declare @PF DECIMAL
    declare @IT DECIMAL
    declare @Deductions DECIMAL
    declare @GrossSalary DECIMAL
    declare @NetSalary DECIMAL

	--Calculate HRA  as 10% Of sal
    SET @HRA = 0.10 * @basic_sal
	--Calculate DA as  20% of sal
    SET @DA = 0.20 * @basic_sal
	--Calculate PF as 8% of sal
    SET @PF = 0.08 * @basic_sal
	--Calculate IT as 5% of sal
    SET @IT = 0.05 * @basic_sal

    -- Calculate Deductions as sum of PF and IT
    SET @Deductions = @PF + @IT

    -- Calculate Gross Salary as sum of SAL,HRA,DA
    SET @GrossSalary = @basic_sal + @HRA + @DA

    -- Calculate Net salary as  Gross salary- Deduction
    SET @NetSalary = @GrossSalary - @Deductions

    -- Display the payslip
    PRINT 'Employee Payslip for EmployeeID: ' + CAST(@EMPNO AS VARCHAR(10))
    PRINT '-------------------------------'
    PRINT 'Basic Salary: ' + CAST(@basic_sal AS VARCHAR(10))
    PRINT 'HRA: ' + CAST(@HRA AS VARCHAR(10))
    PRINT 'DA: ' + CAST(@DA AS VARCHAR(10))
    PRINT 'PF: ' + CAST(@PF AS VARCHAR(10))
    PRINT 'IT: ' + CAST(@IT AS VARCHAR(10))
    PRINT 'Deductions: ' + CAST(@Deductions AS VARCHAR(10))
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(10))
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(10))
END
EXEC GeneratePayslip 7698