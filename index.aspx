<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Index</title>
    <link rel="stylesheet" href="Scripts/index.css"/>
    <link rel="stylesheet" href="Scripts/fab.css" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="Scripts/carouFredsel.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.2/css/all.css">
</head>
<body>
    <nav class="navbar sticky-top navbar-expand-lg navbar-dark">
        <div class="container mynav">
            <a class="navbar-brand" style="color:#EEFFFF;" href="#"><img src="Images/8104.jpg" width="64px" height="64px;">&nbsp;Syndicate <span style="color:yellow;"> Constructions </span> India</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#myNavbarToggler13" aria-controls="myNavbarToggler13" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="myNavbarToggler13">
                <ul class="navbar-nav mx-auto">
                    <li class="nav-item myitem">
                        <a class="nav-link mynav-link" href="#">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#intro">About</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#intro">Work</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#feature">Services</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#testimonial">Clients</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#contact">Contact</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <section class="slider">
        <ul class="slider-carousel" id="slider-carousel">
            <li class="img1">
                <h2>Beautified and <span>Fully Furbished</span> Houses</h2>
                <p>We believe in creativity always</p>
                <p>DO visit the stores to get our AR software</p>
                <i class="fab fa-apple"></i>
                <i class="fab fa-windows"></i>
                <i class="fab fa-android"></i>
                <p>
                    We at Syndicate <span style="color:yellow;"> Constructions </span> India, always produce construct Beautiful,Fully furbished and out of the box designed houses. <br />Which are most prefered by our customers all over India.
                </p>
                <a href="Signup.aspx" class="btn btn-half">Get started</a>
                <a href="" class="btn btn-full">Buy Now</a>
            </li>
            <li class="img2">
                <h2>Well experinced <span> Engineers </span> and <span> Constructors </span></h2>
                <p>Our Engineers have experince of about 10+ years.</p>
                <i class="fab fa-apple"></i>
                <i class="fab fa-windows"></i>
                <i class="fab fa-android"></i>
                <p>
                    We have a very good and experinced team of employees just to buid your homes in matter of months. <br/> Our employees come up with solutions to any construction related problems very fast <br/> We always provide our customers a hazel free construction services.<br />
                </p>
                <a href="Signup.aspx" class="btn btn-half">Get started</a>
                <a href="" class="btn btn-full">Buy Now</a>
            </li>
            <li class="img3">
                <h2 style="color:#db0c0c;">24x7<span> Support </span></h2>
                <p>Our Support is 24x7 no matter where you are we always have yur back.</p>
                <i class="fab fa-apple"></i>
                <i class="fab fa-windows"></i>
                <i class="fab fa-android"></i>
                <p>
                    We have a good and a very helpful customer service team which strives for the smooth and hazel free experince of the customers. <br/> Our Team is appriciated by each and every customer who have had transactions with us.<br/>Our Bot(MADDOX) help in imaproving customer service platform providing more support options for our customers.<br />

                </p>
                <a href="Signup.aspx" class="btn btn-half">Get started</a>
                <a href="" class="btn btn-full">Buy Now</a>
            </li>
        </ul>
    </section>
    <section class="intro-aria white" id="intro">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <h4>Welcome To</h4>
                    <h1>Syndicate <span style="color:#ff0;">Constructions</span> India</h1>
                    <div class="sub-heading">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <div class="intro-block">
                        <span class="intro-icon"><i class="fas fa-question"></i></span>
                        <h3>What We Do ?</h3>
                        <p>Here at Syndicate <span style="color:#ff0;">Constructions</span> India, we offer top quality construction services, no matter how big or small your job. Our team have expert knowledge and skills required to ensure professional work for your next residential project.</p>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="intro-block">
                        <span class="intro-icon"><i class="fas fa-book-reader"></i></span>
                        <h3>Our Approach</h3>
                        <p>We aim to achieve your dreams by giving you the most reliable, qualified professionals to undertake all aspects of your next project. We’re proud to provide an all in one service to our clients.</p>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="intro-block">
                        <span class="intro-icon"><i class="fab fa-angellist"></i></span>
                        <h3>Our Mission</h3>
                        <p>Our mission is to aim for complete client satisfaction, by delivering all construction projects within budget, time scale and to the highest of standards.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="feature-area p-5" id="feature">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <div class="title">
                        <h2>Why choose us?</h2>
                        <div class="sub-heading">
                            <p>Here at Syndicate <span style="color:#ff0;"> Constructions </span> India, we offer top quality construction services, no matter how big or small your job. Our team have expert knowledge and skills required to ensure professional work for your residential project.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-lg-8">
                    <div class="feature-block">
                        <div class="single-feature feature-circle text-center">
                            <div class="circle"></div>
                            <span class="featured-icon"><i class="fas fa-tachometer-alt"></i></span>
                            <h4>UNIQUE DASHBOARD</h4>
                            <span style="color:#EEFFFF;">We provide unique dashboard options for every users. This includes stuff like.</span>
                            <ol style="color:#EEFFFF;">
                                <li>Requesting a Quotation</li>
                                <li>Work Progress Completion</li>
                            </ol>
                        </div>
                        <div class="single-feature feature-circle text-center">
                            <span class="featured-icon"><i class="fas fa-star-half-alt"></i></span>
                            <h4>ROBUST DEMO PACKAGES</h4>
                            <p>When selecting the house models we provide much more robust demo packages. Compare to others our demo packages are liked by every client.</p>
                        </div>
                        <div class="single-feature feature-circle text-center">
                            <span class="featured-icon"><i class="fas fa-expand-arrows-alt"></i></span>
                            <h4>EASY TO USE</h4>
                            <p>This site is developed in such a way that its</p>
                            <ol style="color:#EEFFFF;">
                                <li>Informative</li>
                                <li>Easy to be Used</li>
                            </ol>
                        </div>
                        <div class="single-feature feature-circle text-center">
                            <span class="featured-icon"><i class="fas fa-comment-dots"></i></span>
                            <h4>WELL BUILT CHAT BOT</h4>
                            <p>Our chat bot (MADDOX) is well built to provide support for every customers and ensures a hazel free transaction with us.</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-4 col-lg-4">
                    <div class="feature-mockup">
                        <img class="img-fluid" src="assets/Images/ee4bc243181ffcfc376ea5345c62bfe2.png">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="more-features p-5" id="more-features">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <div class="title">
                        <h2>Other Features Offered</h2>
                        <div class="sub-heading">
                            <p>Other than the above mentioned feature we procide so many other feature that are required for a client when constructing their dream house, flats,villas etc.<br /><span style="color:#EEFFFF;">Some Other important features are as follows</span></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-md-7">
                    <img src="assets/Images/ee4bc243181ffcfc376ea5345c62bfe2.png" class="img-fluid">
                </div>
                <div class="col-sm-12 col-md-5">
                    <div class="feature-list">
                        <ul>
                            <li>
                                <div class="feature-icon">
                                    <i class="fas fa-vr-cardboard"></i>
                                </div>
                                <div class="feature-details">
                                    <h3>3D VIEWER</h3>
                                    <p>Our well experinced designer team construct beautiful and high quality 3D images for the customers to look at when choosing a house model. Which can be view directly form the users's Mobiles/Laptops without any extra software required</p>
                                </div>
                            </li>
                            <li>
                                <div class="feature-icon">
                                    <i class="fas fa-file-pdf"></i>
                                </div>
                                <div class="feature-details">
                                    <h3>DOCUMENTATION</h3>
                                    <p>Our support team collects data that have uploaded to the websites that containg information about Land, Property, and also other information provided by the Govt with respect to the building construction.</p>
                                    <p>Make the information pool and keep it as a simple pdf document which can be used and viewed by anyone who uses this website.</p>
                                </div>
                            </li>
                            <li>
                                <div class="feature-icon">
                                    <i class="fas fa-cogs"></i>
                                </div>
                                <div class="feature-details">
                                    <h3>Settings</h3>
                                    <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Delectus reprehenderit animi odit saepe nostrum voluptatem amet repellendus, rem, accusantium atque neque numquam consequuntur quas incidunt blanditiis velit est in tempora?</p>
                                </div>
                            </li>
                            <li>
                                <div class="feature-icon">
                                    <i class="fas fa-mobile-alt"></i>
                                </div>
                                <div class="feature-details">
                                    <h3>Universal Viewing</h3>
                                    <p>Our website can be viewed by enyone and everyone irrespective of the location, type of device, etc.</p>
                                    <p>Any one can view this on devices such as TV, Mobiles(Android,IoS), Laptops runing on Windows,Linux,MAC OS, Chrome Books, etc.. </p>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="testimonials p-5" id="testimonial">
        <div class="container text-center">
            <div class="sub-heading">
                <h2>What our Clients tell</h2>
                <div class="row p-4">
                    <div class="col-sm-6 text-center">
                        <i class="fa fa-quote-right" style="font-size:25px;padding:15px;color:#c50808;border:2px solid #c50808; border-radius:75%;"></i>
                        <p class="p-2">Syndicate <span style="color:yellow;"> Constructions </span> India are great to work with. Really professional team of experts. Would highly recommend.</p>
                        <br />
                        <p>Mark E.</p>
                    </div>
                    <div class="col-sm-6 text-center">
                        <i class="fa fa-quote-right" style="font-size:25px;padding:15px;color:#c50808;border:2px solid #c50808; border-radius:75%;"></i><br>
                        <p class="p-2">Great team to work with. 100% recommend.</p>
                        <br />
                        <p>Jasmine G.</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators p-10">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img class="mx-auto d-block myimg" src="assets/Vectors/1.png" alt="First slide">
                                <div class="d-none d-md-block">
                                    <h2>Tim Johnson</h2>
                                    <h4>Sr.Engineer</h4>
                                    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Molestiae recusandae fugit tenetur voluptatum cum, necessitatibus sunt fuga corporis reiciendis accusantium eos dolor non itaque laborum nostrum. Magni culpa ut fugit!</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img class="mx-auto d-block myimg" src="assets/Vectors/2.png" alt="Second slide">
                                <div class="d-none d-md-block">
                                    <h2>Tim Johnson</h2>
                                    <h4>Sr.Engineer</h4>
                                    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Molestiae recusandae fugit tenetur voluptatum cum, necessitatibus sunt fuga corporis reiciendis accusantium eos dolor non itaque laborum nostrum. Magni culpa ut fugit!</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img class="mx-auto d-block myimg" src="assets/Vectors/1.png" alt="Third slide">
                                <div class="d-none d-md-block">
                                    <h2>Tim Johnson</h2>
                                    <h4>Sr.Engineer</h4>
                                    <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Molestiae recusandae fugit tenetur voluptatum cum, necessitatibus sunt fuga corporis reiciendis accusantium eos dolor non itaque laborum nostrum. Magni culpa ut fugit!</p>
                                </div>
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div> 
            </div>
        </div>
    </section>
    <section class="team-area" id="team">
        <div class="container p-5">
            <div class="row">
                <div class="col-sm-6 text-center">
                    <h2>OUR DRIVING FORCE</h2>
                    <hr>
                    <p>We’re proud to be a diverse, global team united by values including openness, positivity, and drive that stems from our founders. No matter how much our teams grow, we still feel like family.</p>
                </div>
                <div class="col-sm-6">
                    <img src="assets/Images/A-driving-force_0.jpg" class="img-fluid">
                </div>
            </div>
        </div>
    </section>
    <section class="download text-center p-5" id="download">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="title">
                        <h2>Download</h2>
                        <div class="sub-heading">
                            <p>Please click on the bellow button to get more information regarding the construction related documents/rules provided by the Govt. of India</p>
                        </div>
                    </div>
                </div>
                <div class="social-btn text-center">
                    <div class="row">
                        <div class="col-sm-12 text-center">
                            <a href="" class="btn default-btn mx-auto"><i class="fas fa-cloud-download-alt"></i>Download Related Documents</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="contact-area" id="contact">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 text-center">
                    <h2>Contact Us</h2>
                    <div class="sub-heading">
                        <p>Please drop a message/comment to get in touch with us or use our user friendly chat-bot MADDOX <br />
                        <span style="color:#EEFFFF;">If you feel like visiting us please come to the below mentioned address<br />
                        Or also can call our 24x7 customer helpline.</span> </p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 divider p-2">
                    <h3>Contact</h3>
                    <hr>
                    <div class="contact-address">
                        <ul>
                            <li>
                                <i class="fas fa-home"></i>
                                <div class="address-phone">
                                    <h4>Address</h4>
                                    <span>54A Church Road, Ashford, Middleex, TW15 2TS, India</span>
                                </div>
                            </li>
                            <li>
                                <i class="fas fa-blender-phone"></i>
                                <div class="address-phone">
                                    <h4>Phone</h4>
                                    <span>1234567890</span>
                                </div>
                            </li>
                            <li>
                                <i class="fas fa-at"></i>
                                <div class="address-phone">
                                    <h4>E-Mail</h4>
                                    <span>someone@email.com</span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="contact-block p-2">
                        <h3>Drop a Message</h3>
                        <hr>
                        <form class="contact-form">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="First Name" required>
                                    </div>
                                    <div class="form-group">
                                        <input type="email" class="form-control" placeholder="someone@email.com" required>
                                    </div>
                                    <div class="form-group">
                                        <input type="number" class="form-control" required placeholder="Phone Number">
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <textarea class="form-control" placeholder="Messages" required></textarea>
                                    </div>
                                    <div class="form-group">
                                        <input type="Submit" class="btn default-btn btn-block" value="Submit">
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="Scripts/main.js"></script>
</body>
</html>