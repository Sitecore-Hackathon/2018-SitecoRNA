![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Sitecore Speech Experience Connect (SXC)

SXC is a POC module for connecting recorded speech to Sitecore xConnect. The goal behind the module was to prove that there would be a way to use speech recognition to figure out information about a contact on an external site, and to send the discovered information to xConnect for future personalization and analytics.

While SXC may not be complete, it is the product of Varun Nehra and Zachary Kniebel's Sitecore Hackathon 2018 labors, and it is complete enough to prove that the goals behind it are feasible.

## Features (included and desired)

* Say occupation on external site -> scored in Sitecore and personalized based on it when visiting Sitecore site (mostly working, but a little broken - more on this later)
* Create 20 questions to figure more out about a person (not enough time, but clearly doable)
* Dynamic questions that respond to information given already, i.e. strategic questions chosen by AI (know it's feasible, but not proven in this code)

## Issues

We ran into a few issues when it came time to put all of our pieces together. First, while the demo site that we have would pass a wav file to our service, the wav mime type technically wasn't supported (not written in any documentation that we could find), and it was too late to make a new external application demo. Second, we spent a lot of time trying to figure out what was wrong with our wav files, becasue we didn't know about the wave mime type issue. Third, because of the first two issues, we ran out of time to figure out how to properly deserialize the response object from Microsoft and extract our value from it, and so we had to hardcode the "developer" occupation for submission.

## Setup

Build, publish to the site, sync TDS, and be sure to add Access-Control-Allow-Origin \* to the web.config. If you want to use credentials for the Microsoft Speech API then update the settings in the /App\_Config/Include/Feature/Speech.Microsoft.Speech.Api.config. 

To run the "external app demo", which works but sends a bad wav file, you can open the /ExternalAppDemo/index.html file and follow along with the video. 

## Supported Occupations in Demo to Say

* Developer
* Marketer
* Other



