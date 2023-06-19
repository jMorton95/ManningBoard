module.exports = {
  env: {
    browser: true,
    es2021: true
  },
  extends: [
    'standard-with-typescript',
    'plugin:react/recommended'
  ],
  parserOptions: {
    ecmaVersion: 'latest',
    sourceType: 'module',
    project: './tsconfig.json'
  },
  plugins: [
    'react'
  ],
  rules: {
    semi: ['warn', 'always'],
    '@typescript-eslint/semi': ['off', 'never'],
    indent: ['warn', 2, {
      SwitchCase: 1,
      VariableDeclarator: { var: 2, let: 2, const: 3 },
      ignoredNodes: ['ConditionalExpression']
    }],
    'react/react-in-jsx-scope': 'off',
    'space-before-function-paren': ['error', 'never'],
    '@typescript-eslint/space-before-function-paren': ['error', 'never'],
    'spaced-comment': ['error', 'never'],
    '@typescript-eslint/consistent-type-definitions': ['error', 'type']
  }
};
