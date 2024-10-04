﻿
namespace EntityLayer.Concrete;

public class About : BaseEntity
{
    public string AboutDetails1 { get; set; }
    public string AboutDetails2 { get; set; }
    public string AboutImage1 { get; set; }
    public string AboutImage2 { get; set; }
    public string AboutMapLocation { get; set; }
    public bool AboutStatus { get; set; }
}

public class AboutResponseDto
{
    public string AboutDetails1 { get; set; }
    public string AboutDetails2 { get; set; }
    public string AboutImage1 { get; set; }
    public string AboutImage2 { get; set; }
    public string AboutMapLocation { get; set; }
    public bool AboutStatus { get; set; }
}
