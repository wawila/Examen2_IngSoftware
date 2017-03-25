Feature: ConvertionFeatures
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: CSV to JSON
	Given I have the next CSV 'ID, Nombre, Fecha\n0, Sully, #10/12/1998#\n1, Napky, #21/8/2001#\n2, David, #23/5/1897#'
	When I press convert to JSON
	Then the result should be '{0: {"ID":0, "Nombre": "Sully", "Fecha": 1998-12-10T00:00.0000000}, 1: {"ID":1, "Nombre": "Napky", "Fecha": 2001-08-21T00:00.0000000}, 2: {"ID":2, "Nombre": "David", "Fecha": 1897-05-23T00:00.0000000}}'

Scenario: CSV to XML
Given I have the next CSV 'ID, Nombre, Fecha\n0, Sully, #10/12/1998#\n1, Napky, #21/8/2001#\n2, David, #23/5/1897#'
	When I press convert to XML
	Then the result should be 