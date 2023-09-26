/**
 * Creating a sidebar enables you to:
 - create an ordered group of docs
 - render a sidebar for each doc of that group
 - provide next/previous navigation

 The sidebars can be generated from the filesystem, or explicitly defined here.

 Create as many sidebars as you want.
 */

// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  docs: [
    'overview',
    'installation',
    {
      type: 'category',
      label: 'Identity and Access Management',
      items: [
        'iam/authmethods',
        'iam/externalidproviders',
        {
          type: 'category',
          label: 'Identity Provisioning',
          items: [
            'iam/automaticidentityprovisioning',
            'iam/manualidentityprovisioning'
          ]
        },
        {
          type: 'category',
          label: 'Security protocols',
          items: [
            'iam/openid',
            'iam/saml2',
            'iam/wsfederation'
          ]
        },
        'iam/storage',
        'iam/configuration'
      ]
    },
    'scim20'
  ],
  tutorials: [
    'tutorial/overview',    
    { 
      type: 'category', 
      label: 'Tutorial',       
      items: [ 'tutorial/spa', 'tutorial/regularweb', 'tutorial/protectapi', 'tutorial/m2m', 'tutorial/wsfederation', 'tutorial/highlysecuredregularweb', 'tutorial/ciba', 'tutorial/grantmgt' ] 
    }
  ]
  // By default, Docusaurus generates a sidebar from the docs folder structure
  /*
  documentationSidebar: [
    {type: 'autogenerated', dirName: '.'}
  ]
  */
};

module.exports = sidebars;
