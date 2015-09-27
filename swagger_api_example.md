swagger: '2.0'
info:
  version: "1.0.0"
  title: RESTful API Definition and JSON Objects
  description: |
    ### Author: Brendon Price
    ### Version: 2.8
    ### Last Updated: 23/03/2015  
    
    ## Document History
    + 28/10/2014 - Initial version 2.0 of API document released.
    + 05/11/2014 - v2.1 Added the __"popularStoriesSupplement"__ and __"featuredStoriesSupplement"__ to hold Analytics and Advertising keys. So each feed has its own Ad keys and Analytics data.
    + 10/11/2014 - v2.2 Add the Image request API. Also updated the Story API with optional "adKeys" element.
    + 14/11/2014 - v2.3 Added the Supplement Info to the detailed Weather API call, so we can display Ad's on the weather screens.
    + 25/11/2014 - v2.4 Added the Supplement Info to the Video JSON object, so we can hold adKeys and Omniture keys for IMA. Inline with discussions with Sunny around Video IMA.
    + 01/12/2014 - v2.5 Refactored the NZ Weather forecast JSON structure, so we can support Headings and sub-headings for a forecast, e.g. Coastal and Leisure forecasts . Also added the PUSH Notification structure for breaking news item. 
    + 05/12/2014 - v2.6 Added Video objects directly to the watch now schedule, so we can directly play the live watch now stream.
    + 11/02/2015 - v2.7 Updated to include Map Story body part, and updates to example data included in documentation. Also included example Omniture keys per API, inline with initial testing of Analytics.
    + 23/03/2015 - v2.8 Updated detail description for Weather API calls.
host: cmsstage.tvnz.co.nz
schemes:
  - https
securityDefinitions:
  basicAuth:
    type: basic
    description: HTTP Basic Authentication. Works over `HTTP` and `HTTPS`
paths:
  /summary/{platform}/{version}.json:
    get:
      description: |
        Returns the initial data required to display the home screen of the iOS and Android apps. This call includes an           optional user region specifier that will include the weather condition if present for immediate
        display of correct weather icon in the app header (alternatively this will return data for Auckland when region is         not provided).
        ![Asssociated Imagery](http://images1.fanpop.com/images/image_uploads/Funny-Cat-Pictures-cats-935656_500_375.jpg "asdf")
      parameters:
        - name: platform
          in: path
          description: what is this for
          required: true
          type: string
        - name: version
          in: path
          description: what is this for
          required: true
          type: string
        - name: region
          in: query
          description: what is this for
          required: false
          type: string
      security:
       - basicAuth: []
      responses:
        200:
          description:  Some weather stuff
          schema:
            $ref: '#/definitions/latestHooksSupplement'
            latestHooksSupplement:
              adKeys:
                genre: string "asdf"
                kw: string
                site: string
                prog: string
                chanl: string
                pt: string
                rating: string
                dist: string
                slotName: string
                adPosition: integer
                omnitureKeys: integer
          examples:
            application/json: |-
              {
                "latestHooksSupplement": {
                  "adKeys": {
                      "genre": "new-zealand,factual",
                      "kw": "new-zealand,factual,tv-one,tvnz",
                      "site": "tv",
                      "prog": "tagata-pasifika",
                      "chanl": "tv-one",
                      "pt": "od-showpage",
                      "rating": "PG",
                      "dist": "tvnz",
                      "slotName": "/4180/tablet-test.tvnz/tv//TV1//_//_2572438//_//_2526675//_"
                  },
                  "adPosition": 9,
                  "omnitureKeys": {
                      "eVar1": "news:home",
                      "eVar2": "news:home:latest",
                      "eVar4": "onnnewshome",
                      "eVar70": "ONN",
                      "pageName": "news:home:latest",
                      "hierarchy": "news|home|latest",
                      "channel": "news"
                  }
              }

definitions:
  latestHooksSupplement:
    properties:
      adKeys:
        properties:
          genre:
            type: string
          kw:
            type: string
          site:
            type: string
          prog:
            type: string
          chanl:
            type: string
          pt:
            type: string
          rating:
            type: string
          dist:
            type: string
          slotName:
            type: string
      adPosition:
        type: integer
        format: int32
      omnitureKeys:
        type: integer
        format: int32
  

